using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using test2Retake.DTOs.Requets;
using test2Retake.DTOs.Responce;
using test2Retake.Exceptions;
using test2Retake.Models;

namespace test2Retake.Services
{
    public class SqlServerFIreFighterDbService : IFireFighterDbService
    {

        public readonly FireFightersDbContext _context;
        public SqlServerFIreFighterDbService(FireFightersDbContext context) {
            _context = context;
        }

        public void AssignTruck(AssignTruckRequest request)
        {
            if (_context.Action.Where(a => a.IdAction == request.IdAction).Count() == 0)
            {
                throw new NoSuchActionException();
            }
            else
            {
                bool needEquipment = _context.Action.Where(a => a.IdAction == request.IdAction).Select(a => a.NeedSpecialEquipment).FirstOrDefault();
                if (_context.FireTruck.Where(f => f.IdFireTruck == request.IdFireTruck && f.SpecialEquipment == needEquipment).Count() == 0)
                {
                    throw new NoSuchTruckException();
                }
            }
            int isTruckFree = _context.FireTruck_Action.Join(_context.Action, f => f.IdAction, a => a.IdAction, (f, a) => new { f_truck_act = f, action = a })
                .Where(e => e.action.EndTime == null && e.f_truck_act.IdFireTruck == request.IdFireTruck).Count();
            if (isTruckFree > 0)
            {
                throw new CurrentlyUseSuchTruckException();
            }
            using (var tra = _context.Database.BeginTransaction())
            {
                FireTruck_Action fireTruck_Action = new FireTruck_Action()
                {
                    IdFireTruck = request.IdFireTruck,
                    IdAction = request.IdAction,
                    AssignmentDate = DateTime.Now
                };

                _context.Add<FireTruck_Action>(fireTruck_Action);
                _context.SaveChanges();
                tra.Commit();
            }
        }

        public List<GetListOfActionResponse> getLisiOfAction(int idFireman)
        {
            List<GetListOfActionResponse> actions = new List<GetListOfActionResponse>();
            if (_context.FireFighter.Where(f => f.IdFireFighter == idFireman).Count() == 0)
            {
                throw new NoSuchFireFighterException();
            }

            actions = (List<GetListOfActionResponse>)_context.FireFighter_Action.Join(_context.Action, f => f.IdAction, a => a.IdAction,
                (f, a) => new { f_action = f, action = a })
                .Where(e => e.f_action.IdFireFighter == idFireman && e.action.EndTime != null)
                .Select(e => new GetListOfActionResponse { IdAction = e.action.IdAction, StartTime = e.action.StartTime, EndTime = e.action.EndTime })
                .ToList().OrderByDescending(e => e.EndTime);
            return actions;
        }

    }
}
