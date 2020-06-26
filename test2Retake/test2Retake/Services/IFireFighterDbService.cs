using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2Retake.DTOs.Requets;
using test2Retake.DTOs.Responce;

namespace test2Retake.Services
{
    public interface IFireFighterDbService
    {
        public List<GetListOfActionResponse> getLisiOfAction(int idFireman);
        public void AssignTruck(AssignTruckRequest request);
    }
}
