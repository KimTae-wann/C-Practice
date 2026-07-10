using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1hw1
{
    class Program
    {
        static void Main(string[] args)
        {

            int score;
            score = int.Parse(System.Console.ReadLine());

            if (score > 100 || score < 0)
            {
                System.Console.WriteLine("잘못된 값입니다. 0과 100사이의 값을 입력해주세요");
                return;
            }

            // if / else if / else
            String grade;
            if (score >= 90)
                grade = "A";
            else if (score >= 80)
                grade = "B";
            else if (score >= 70)
                grade = "C";
            else if (score >= 60)
                grade = "D";
            else
                grade = "F";

            System.Console.WriteLine(grade);

            // switch
            int tempScore = score / 10;
            switch(tempScore)
            {
                case 10:
                case 9:
                    /*grade = "A";
                    break;*/
                case 8:
                    grade = "B";
                    break;
                case 7:
                    grade = "C";
                    break;
                case 6:
                    grade = "D";
                    break;
                default:
                    grade = "F";
                    break;
            }
           
            System.Console.WriteLine(grade);
        }
    }
}
