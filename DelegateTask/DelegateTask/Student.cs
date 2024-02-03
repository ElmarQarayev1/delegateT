using System;
namespace DelegateTask
{
	public class Student
	{
		private int _no;
		private string _fullName;

		public int No
		{
			get
			{
			    return _no;
			}
			set
			{
			      if (value > 0)
			      { 
				  _no = value;
			      }
			}
		}
		public string FullName
		{
			get
			{
			    return _fullName;

			}
			set
			{
				if (value.CheckFullname())
				{
					_fullName = value;
				}
			}
		}
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

