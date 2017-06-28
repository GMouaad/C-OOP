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
        public static DataStorage getDataStorage()
        {
            if ( dataStorage == null) 
                dataStorage = new DataStorage(); // this will happen the first time the program runs, where the dataStorage was never created
            return dataStorage;
        }
    }
}
