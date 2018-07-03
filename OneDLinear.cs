using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
//using SmoothingFunctions;


namespace SmoothingFunctions
{

    public static class OneDLinear
    {
        
        public static float Lerp(float start, float end, float progress)
        {
            if (progress > 1f)
            {
                progress = 1f;
            }
            else if (progress < 0f)
            {
                progress = 0f;
            }

            return start + (end - start) * progress;
        }

        public static float SmoothStart(float start, float end, float progress) {

            if (progress > 1f)
            {
                progress = 1f;
            }
            else if (progress < 0f)
            {
                progress = 0f;
            }

            return start + (end - start) * (progress * progress);
        }


        public static float SmoothStartOrder(float start, float end, float progress, int order)
        {
            if (progress > 1f)
            {
                progress = 1f;
            }
            else if (progress < 0f)
            {
                progress = 0f;
            }            
            for (int i = 1; i < order; i++)
            {
                progress *= progress;
            }
            return start + (end - start) * progress;
        }

        public static float SmoothStopOrder(float start, float end, float progress, int order)
        {
            if (progress > 1f)
            {
                progress = 1f;
            }
            else if (progress < 0f)
            {
                progress = 0f;
            }
            progress = 1 - progress;
            for (int i = 1; i < order; i++)
            {
                progress *= (progress);
            }
            return start + (end - start) * (1-Math.Abs(progress));
        }


        public static float SmoothStop(float start, float end, float progress)
        {
            
            if (progress > 1f)
            {
                progress = 1f;
            }
            else if (progress < 0f)
            {
                progress = 0f;
            }

            return start + (end - start) * (1-((1-progress) * (1 - progress)));


        }

        public static float Smooth(float start, float end, float progress) {

            if (progress > 1f)
            {
                progress = 1f;
            }
            else if (progress < 0f)
            {
                progress = 0f;
            }
           

            return CrossFade(SmoothStart(start, end, progress), SmoothStop(start, end, progress), progress);


        }

        public static float SmoothOrder(float start, float end, float progress, int order)
        {
            if (progress > 1f)
            {
                progress = 1f;
            }
            else if (progress < 0f)
            {
                progress = 0f;
            }
            return CrossFade(SmoothStartOrder(start, end, progress, order), SmoothStopOrder(start, end, progress, order), progress);
        }

        public static float SmoothDoubleOrder(float start, float end, float progress, int startOrder, int stopOrder)
        {
            if (progress > 1f)
            {
                progress = 1f;
            }
            else if (progress < 0f)
            {
                progress = 0f;
            }
            return CrossFade(SmoothStartOrder(start, end, progress, startOrder), SmoothStopOrder(start, end, progress, stopOrder), progress);
        }



        private static float CrossFade(float a, float b, float t) {

            return a + t * (b - a);


        }


    }
}


