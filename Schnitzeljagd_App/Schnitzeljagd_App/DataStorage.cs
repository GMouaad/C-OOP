using System;
namespace Schnitzeljagd_App
{
    public class DataStorage
    {
        private static DataStorage dataStorage;
        public LocDataPoint locDataPt;
        public DataStorage()
        {
        }
        public DataStorage getDataStorage()
        {
            dataStorage = new DataStorage();
            return dataStorage;
        }
    }
}
