using Newtonsoft.Json;
using Portfolio.Server.Interfaces;
using Portfolio.Shared;

namespace Portfolio.Server.Repository;

public class BlogsDataRepository : IBlogsDataRepository<BlogModel>
{
    private List<BlogModel> blogs;

    public BlogsDataRepository()
    {
        blogs = new List<BlogModel>()
        {
            new BlogModel(Guid.NewGuid().ToString(), "My New Site", new DateTime(2022, 4, 22), "Hello there! Welcome to my website!","welcomeBlog",

            "Hello there! Welcome to my website! Everything you see is created by me from scratch using ASP.Net Core and Razor pages! My previous website was made in Vue.js but I wanted to learn how to use Razor pages since that was I needed to learn on the job as a .Net developer. I will most likely write mainly about programming and programming-adjacent topics, but I may occasionally dip into other subjects if something catches my attention."
            ),

            new BlogModel(Guid.NewGuid().ToString(), "Independence Day Fireworks By the Lake", new DateTime(2022, 7, 4), "Fireworks look even better by the lake!","fireworksBlog",

            "Fireworks look even better by the lake! I wanted to go see the fireworks at Lake Eola which is in downtown Orlando. However, little did I know until I got there they were so packed around the evenings that I ended up settling at a different lake (Lake Cherokee) and the experience was just as good!",

             new List<VideoUrlModel>() {
                new VideoUrlModel {title = "july_4th_2022_fireworks_lake_cherokee_FL", url = "https://www.youtube.com/embed/JDOvUZ3updU"}
            }),

            new BlogModel(Guid.NewGuid().ToString(), "My Linux-distro Hopping Journey", new DateTime(2022, 6, 25), "Distro hopping was a time-consuming but rewarding experience!","linuxDistroTalk",
            "I wanted to get back into linux this Summer since I used Ubuntu back in my computer science class and really enjoyed it. Back then I did not have enough time to delve into other distros because of juggling with all my classes, so I thought I'd take the time now to get into it. Earlier in May I decided to try out Pop OS because my friend recommended that distro for beginners and it is very simple to set up and get going. PopOS is a distro based on Ubuntu (which is then based on Debian), and I used it for about a month before I felt ready to move onto more intermediate user distros like arch-based ones."),

            new BlogModel(Guid.NewGuid().ToString(), "Last Semester of Grad School", new DateTime(2022, 8, 26), "My final semester of graduate school has begun!","finalSemester",

            "This is it. It's time to apply everything I have learned from college and finish strong! I am taking my final three classes: Incident Response Technologies, Mixed Reality, and Algorithms in Computational Biology. Incident Response technologies is a cybersecurity course that will involve practicing pentesting, which I always wanted to get a feel for what it's like being an ethical hacker. Mixed Reality is a project based course that will induce you to apply everything you learned from the two prereq courses, AR and VR, and work with other classmates in a fast paced environment with weekly deadlines. Initially each student will need to come up with a project idea for getting our foot in the door. So far my idea is to build a VR cooking simulation similar to the official VR cooking game, except my project will include rewinding time to undo mistakes made such as spilling food or liquid on the counter. Lastly Algorithms in Computational Biology, students will learn about various different algorithms that are applicable in the field of bioinformatics such as DNA string processing, finding patterns in strings using KMP algorithm, and so much more. I was pre-med for my first semester of undergrad, so it is nice to have a class where I can still apply what I learned in the past despite not being in that field anymore."),
        };
    }

    public async Task<string> GetById(string id)
    {
        await Task.Delay(1);
        var model = blogs.FirstOrDefault(o => o.Id == id);
        return model is null ? "" : JsonConvert.SerializeObject(model, Formatting.Indented);
    }

    public IEnumerable<BlogModel> Sort(bool isNewest)
    {
        blogs.Sort((x, y) => isNewest ? x.date.CompareTo(y.date) : y.date.CompareTo(x.date));
        return blogs;
    }

    public async Task<string> GetData()
    {
        await Task.Delay(1);
        return JsonConvert.SerializeObject(blogs, Formatting.Indented);
    }
}

