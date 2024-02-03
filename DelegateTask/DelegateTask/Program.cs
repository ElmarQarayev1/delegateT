using System.Diagnostics;
using DelegateTask;

List<Student> students = new List<Student>();
string opt;
do
{
       ShowMenu();
    opt = Console.ReadLine();
    switch (opt)
    {
        case "1":
            AddStudent(students);
            break;
        case "2":
            AddExam(students);
            break;
        case "3":
            LookOneExam(students);
            break;
        case "4":
            LookAllExams(students);
            break;
        case "5":
            AvarageExamsPointForStudent(students);
            break;
        case "6":
            RemoveExam(students);
            break;
        case "0":
            Console.WriteLine("program bitdi!");
            break;
        default:
            Console.WriteLine("secim yanlisdir!");
            break;
    }

} while (opt!="0");

static void ShowMenu()
{
    Console.WriteLine("1. Tələbə əlavə et");
    Console.WriteLine("2. Tələbəyə imtahan əlavə et");
    Console.WriteLine("3. Tələbənin bir imtahan balına bax");
    Console.WriteLine("4. Tələbənin bütün imtahanlarını göstər");
    Console.WriteLine("5. Tələbənin imtahan ortalamasını göstər");
    Console.WriteLine("6. Tələbədən imtahan sil");
    Console.WriteLine("0. Proqramı bitir");
    Console.Write("secim edin: ");
}
static void AddStudent(List<Student> students)
{ 
    fullname1:
    Console.WriteLine("Fullname daxil edin:");
    string fullname = Console.ReadLine();
    if (!fullname.CheckFullname())
    {
        Console.WriteLine("duzgun daxil edin!");
        goto fullname1;
    }
    Student student = new Student()
    {
        FullName = fullname
    };
    students.Add(student);
}
static void AddExam(List<Student> students)
{
    studentNo1:
    Console.WriteLine("telebe nomresi daxil edin:");
    string studentNoStr = Console.ReadLine();
    int studentNo;
    if (!int.TryParse(studentNoStr, out  studentNo))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto studentNo1;
    }
    if(studentNo <= 0)
    {

        Console.WriteLine("menfi ola bilmez ve ya 0 ola bilmez!");
        goto studentNo1;
    }
    if(studentNo > students.Count)
    {
        Console.WriteLine("telebenin nomresi telebelerin sayindan cox ola bilmez!");
        return;
    }
examName1:
    Console.WriteLine("imtahan adini daxil edin:");
    string examName = Console.ReadLine();
    if (String.IsNullOrWhiteSpace(examName))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto examName1;
    }
    examPoint1:
    Console.WriteLine("imtahan balini daxil edin:");
    string examPointStr = Console.ReadLine();
    double examPoint;
    if(!double.TryParse(examPointStr,out examPoint))
    {
        Console.WriteLine("duzgun daxil edin:");
        goto examPoint1;
    }
    if(examPoint<0 || examPoint > 100)
    {
        Console.WriteLine("exam pointi 0 la 100 arasinda olmalidir!");
        goto examPoint1;
    }
    students[studentNo - 1].AddExam(examName.Trim(), examPoint);
}
static void LookOneExam(List<Student> students)
{
    studentNo2:
    Console.WriteLine("Baxmaq istediyiniz telebe nomresini daxil edin:");
    string studentNoStr = Console.ReadLine();
    int studentNo;
    if (!int.TryParse(studentNoStr, out studentNo))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto studentNo2;
    }
    if (studentNo <= 0)
    {
        Console.WriteLine("menfi ola bilmez ve ya menfi ola bilmez!");
        goto studentNo2;
    }
    if (studentNo > students.Count)
    {
        Console.WriteLine("telebenin nomresi telebelerin sayindan cox ola bilmez!");
        return;
    }
examName2:
    Console.WriteLine("baxmaq istediyiniz imtahan adini daxil edin:");
    string examName = Console.ReadLine();
    if (String.IsNullOrWhiteSpace(examName))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto examName2;
    }
    Student student = students[studentNo - 1];
    double examResult = students[studentNo - 1].GetExamResult(examName);
    if (examResult != -1)
    {
        Console.WriteLine($"{studentNo} nomreli {student.FullName}  ucun {examName} imtahaninin bali: {examResult}");
    }
    else
    {
        Console.WriteLine("telebenin bu adli exami yoxdur!");
    }
}
static void LookAllExams(List<Student> students)
{
    studentNo3:
    Console.WriteLine("Baxmaq istediyiniz telebe nomresini daxil edin:");
    string studentNoStr = Console.ReadLine();
    int studentNo;
    if (!int.TryParse(studentNoStr, out studentNo))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto studentNo3;
    }
    if (studentNo <= 0)
    {

        Console.WriteLine("menfi ola bilmez ve ya 0 ola bilmez!");
        goto studentNo3;
    }
    if (studentNo > students.Count)
    {
        Console.WriteLine("telebenin nomresi telebelerin sayindan cox ola bilmez!");
        return;
    }
    Student student = students[studentNo - 1];

    Console.WriteLine($"{studentNo} nomreli {student.FullName} ucun butun imtahanlar ve ballari:");

    foreach (var item in student.examPoint)
    {
        Console.WriteLine($"Imtahan adi: {item.Key}- Bal: {item.Value}");
    }
}
static void AvarageExamsPointForStudent(List<Student> students)
{
    studentNo4:
    Console.WriteLine("Baxmaq istediyiniz telebe nomresini daxil edin:");
    string studentNoStr = Console.ReadLine();
    int studentNo;
    if (!int.TryParse(studentNoStr, out studentNo))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto studentNo4;
    }
    if (studentNo <= 0)
    {
        Console.WriteLine("menfi ola bilmez ve ya 0 ola bilmez!");
        goto studentNo4;
    }
    if (studentNo > students.Count)
    {
        Console.WriteLine("telebenin nomresi telebelerin sayindan cox ola bilmez!");
        return;
    }
    Student student = students[studentNo - 1];

    double examAverage = student.GetExamAvg();

    if (examAverage != -1)
    {
        Console.WriteLine($"{studentNo} nomreli {student.FullName} ucun butun imtahanlarin ortalama bali: {examAverage}");
    }
    else
    {
        Console.WriteLine("exam tapilmadi");
    }
}
static void RemoveExam(List<Student> students)
{
studentNo5:
    Console.WriteLine("silmek istediyiniz exam ucun telebe nomresini daxil edin:");
    string studentNoStr = Console.ReadLine();
    int studentNo;
    if (!int.TryParse(studentNoStr, out studentNo))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto studentNo5;
    }
    if (studentNo <= 0)
    {
        Console.WriteLine("menfi ola bilmez ve ya 0 ola bilmez!");
        goto studentNo5;
    }
    if (studentNo > students.Count)
    {
        Console.WriteLine("telebenin nomresi telebelerin sayindan cox ola bilmez!");
        return;
    }
    examName1:
    Console.WriteLine("imtahan adini daxil edin:");
    string examName = Console.ReadLine();
    if (String.IsNullOrWhiteSpace(examName))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto examName1;
    }
    Student student = students[studentNo - 1];
    bool check = students[studentNo - 1].examPoint.Remove(examName.Trim());
    if (check)
    {
        Console.WriteLine($"{studentNo} nomreli {student.FullName} ucun {examName} imtahani silindi");
    }
    else
    {
        Console.WriteLine($"{studentNo} nomreli {student.FullName} ucun {examName} imtahani tapilmadi");
    }
}
