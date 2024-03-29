﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASchoolQuizIII
{
    public class ASchoolQuizIII
    {
        //Your Code is Here:
        //==================
        /// <summary>
        /// Check if the sum of any set of integers from the board gives ‘N’ or not
        /// </summary>
        /// <param name="numbers">set of positive integers on the board</param>
        /// <param name="N">number of items</param>
        /// <param name="value">number that the teacher ask students to check against it</param>
        /// <returns>true if exists, false otherwise</returns>
        public static bool SchoolQuiz(int[] numbers, int N, int value)
        {
            // Your code here...

            int[,] dp = new int[N+1,value+1];
            for (int i = 0; i <= N; i++) for (int j = 0; j <= value; j++) dp[i, j] = -1;
            int flag = solve(0, value, numbers, dp, N);
            if (flag == 1) return true;
            else  return false;
           // throw new NotImplementedException();
        }
        
        public static int solve(int m,int n, int[] arr , int [,] dp, int size)
        {
            if (n == 0) return 1;
            if (m == size) return 0;

            if (dp[m, n] != -1) return dp[m, n];

            int ret = solve(m + 1, n,arr,dp, size);

            if(n>=arr[m])
            {
                int ret2=solve(m + 1, n-arr[m], arr, dp, size);
                ret = Math.Max(ret, ret2);
            }
            dp[m, n] = ret;

           return ret;
           

        }
    }
}

