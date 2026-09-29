
SurveyRun surveyRun =new();
// surveyRun.AddQuestion(QuestionType.Text, default);
surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever thrown a NullReferenceException?");
surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happened?"));
surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");
surveyRun.PerformSurvey(50);
int popo=0;
int jojo=0;
foreach(var person in surveyRun.AllParticipants)
{
  popo++;
  Console.WriteLine($"{popo}.id为{person.Id}的人：");
  if (person.AnsweredSurvey)
  {
    for(int i = 0; i < surveyRun.Questions.Count; i++)
    {
        if(person.Answer(i)!="No answer"){
          Console.WriteLine($"第{i+1}个问题的回答是{person.Answer(i)}");
        }
      else
      {
      Console.WriteLine($"第{i+1}个问题没有回答");
      }
      
    }
  }
  else
      {
        jojo++;
      Console.WriteLine("拒绝了采访");
      }
}
Console.WriteLine(popo-jojo);
public class SurveyRun
{
    private List<SurveyQuestion> surveyQuestions = [];

    public void AddQuestion(QuestionType type, string question) =>
        AddQuestion(new SurveyQuestion(type, question));

    public void AddQuestion(SurveyQuestion surveyQuestion) =>
        surveyQuestions.Add(surveyQuestion);
    private List<SurveyResponse>? respondents;
    public void PerformSurvey(int numberOfRespondents)
    {
    int respondentsConsenting = 0;
    respondents = [];
    while (respondentsConsenting < numberOfRespondents)
    {
      //这里创建一个带id的参加者
        var respondent = SurveyResponse.GetRandomId();
        if (respondent.AnswerSurvey(surveyQuestions))
      //直到回答的参加者达到要求数量numberOfRespondents就结束
            respondentsConsenting++;
      //不管这个参加者有没有回答都被纳入其中
        respondents.Add(respondent);
    }
}
public IEnumerable<SurveyResponse> AllParticipants => (respondents ?? Enumerable.Empty<SurveyResponse>());
public ICollection<SurveyQuestion> Questions => surveyQuestions;
public SurveyQuestion GetQuestion(int index) => surveyQuestions[index];
}
public enum QuestionType
{
    YesNo,
    Number,
    Text
}
public class SurveyQuestion(QuestionType type, string question)
{
  public QuestionType Type{get;}=type;
  public string QuestionText{get;}=question;
}
public class SurveyResponse(int id)
{
    public int Id { get; } = id;
    private static readonly Random randomGenerator = new Random();
    public static SurveyResponse GetRandomId() => new SurveyResponse(randomGenerator.Next());
    private Dictionary<int, string>? surveyResponses;
    //用于判断某个人是否接受采访，同时记录回答
    public bool AnswerSurvey(IEnumerable<SurveyQuestion> questions)
    {
      //是否接受采访
    if (ConsentToSurvey())
    {
        surveyResponses = new Dictionary<int, string>();
        int index = 0;
      //遍历所有问题
        foreach (var question in questions)
        {
            var answer = GenerateAnswer(question);
            if (answer != null)
            {
                surveyResponses.Add(index, answer);
            }
            index++;
        }
    }
    //如果没有接受采访，就返回false，只有接受采访才创建这个对象
    return surveyResponses != null;
}
//是否接受
    private bool ConsentToSurvey() => randomGenerator.Next(0, 2) == 1;
//获取随机回答  
    private string? GenerateAnswer(SurveyQuestion question)
{
    switch (question.Type)
    {
        case QuestionType.YesNo:
            int n = randomGenerator.Next(-1, 2);
            return (n == -1) ? default : (n == 0) ? "No" : "Yes";
        case QuestionType.Number:
            n = randomGenerator.Next(-30, 101);
            return (n < 0) ? default : n.ToString();
        case QuestionType.Text:
        default:
            switch (randomGenerator.Next(0, 5))
            {
                case 0:
                    return default;
                case 1:
                    return "Red";
                case 2:
                    return "Green";
                case 3:
                    return "Blue";
            }
            return "Red. No, Green. Wait.. Blue... AAARGGGGGHHH!";
    }
}
public bool AnsweredSurvey => surveyResponses != null;
public string Answer(int index) => surveyResponses?.GetValueOrDefault(index) ?? "No answer";
} 