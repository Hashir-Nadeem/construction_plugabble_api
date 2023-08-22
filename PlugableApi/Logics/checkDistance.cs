using Nest;
using NetTopologySuite.Geometries;
using PlugableApi.Models;
using System.Runtime.InteropServices;
using Location = PlugableApi.Models.Location;

namespace PlugableApi.Logics
{
    public static  class checkDistance
    {
        public static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
        public static double distance(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                dist = dist * 1.609344;//km
                dist = dist * 1000;//m
                
                return (dist);
            }
        }
        public static bool distance(List<JobLocation>Joblocations, double lat2, double lon2, char unit='K')
        {
            
            foreach(var joblocation in Joblocations)
            {
                var dist = distance(Convert.ToDouble(joblocation.Location.Latitude), Convert.ToDouble(joblocation.Location.Longitude),
                    lat2,lon2);
                if(dist==0 || dist <=Convert.ToDouble(joblocation.Location.Defaults.Radius))
                {
                    return true;//also sent job id name here to identify tha job

                }
               

            }
            return false;
            
        }
    }
}
