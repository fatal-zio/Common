using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Common
    {
        private static string ResolveWindDirectionFromDegrees(int degrees)
        {
            var directionResult = string.Empty;

            var cases = new Dictionary<Func<int, bool>, Action>
            {
                { x => x == 0 ,   () => directionResult = "CLM" } ,
                { x => x < 24 ,    () => directionResult = "N" } ,
                { x => x < 68 ,   () => directionResult = "NE" } ,
                { x => x < 113 ,  () => directionResult = "E" } ,
                { x => x < 158 ,   () => directionResult = "SE" } ,
                { x => x < 203 ,   () => directionResult = "S" } ,
                { x => x < 248 ,   () => directionResult = "SW" } ,
                { x => x < 293 ,   () => directionResult = "W" } ,
                { x => x < 338 ,   () => directionResult = "NW" } ,
                { x => x < 361 ,   () => directionResult = "N" }
            };

            cases.First(kvp => kvp.Key(degrees)).Value();

            return directionResult;
        }
    }
}