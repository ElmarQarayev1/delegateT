using System;
namespace DelegateTask
{
	public class Student
	{
	
		public int No;
		public string FullName;
	    public Dictionary<string, double> examPoint = new Dictionary<string, double>();

		public void AddExam(string examName, double point)
		{
			examPoint.Add(examName, point);

		}
		public double GetExamResult(string examName)
		{
			if (examPoint.ContainsKey(examName))
			{
				return examPoint[examName];

			}
			else
			{
				return -1;
			}

		}
        public double GetExamAvg()
        {
            if (examPoint.Count == 0)
            {
				return -1;
            }

            double totalPoint = 0;
            foreach (var item in examPoint.Values)
            {
                totalPoint += item;
            }

            return totalPoint / examPoint.Count;
        }
    }

}

