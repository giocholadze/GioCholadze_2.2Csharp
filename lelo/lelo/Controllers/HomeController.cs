using Microsoft.AspNetCore.Mvc;
using SportsWebsite.Models;

namespace SportsWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var featuredNews = new NewsItem
            {
                Id = 1,
                Title = "Women's National Team Prepares for Nations League Final Matches",
                Excerpt = "The women's national team has begun preparations for the final matches of the Nations League.",
                Content = "The women's national team has begun intensive preparations for the upcoming Nations League final matches. Coach Sarah Williams has implemented new tactical approaches and the team is showing excellent form in training sessions. The players are confident and ready to face the challenges ahead.",
                Author = "Sports Reporter",
                Category = "Women's Team",
                PublishedDate = DateTime.Now.AddDays(-1),
                ViewCount = 1250,
                ImageUrl = "/images/hero-match.jpg"
            };

            var recentNews = GetRecentNews();
            var upcomingMatches = GetUpcomingMatches();

            ViewBag.FeaturedNews = featuredNews;
            ViewBag.RecentNews = recentNews;
            ViewBag.UpcomingMatches = upcomingMatches;

            return View();
        }

        public IActionResult MensLeague()
        {
            var mensNews = GetMensNews();
            var mensMatches = GetMensMatches();

            ViewBag.MensNews = mensNews;
            ViewBag.MensMatches = mensMatches;

            return View();
        }

        public IActionResult WomensLeague()
        {
            var womensNews = GetWomensNews();
            var womensMatches = GetWomensMatches();

            ViewBag.WomensNews = womensNews;
            ViewBag.WomensMatches = womensMatches;

            return View();
        }

        public IActionResult YouthLeague()
        {
            var youthNews = GetYouthNews();

            ViewBag.YouthNews = youthNews;

            return View();
        }

        private List<NewsItem> GetRecentNews()
        {
            return new List<NewsItem>
            {
                new NewsItem
                {
                    Id = 2,
                    Title = "Men's Team Championship Victory",
                    Excerpt = "Historic victory in the championship final brings glory to the team.",
                    Content = "In a thrilling championship final, our men's team delivered an outstanding performance to secure a historic victory. The match was decided in the final minutes with a spectacular goal that will be remembered for years to come.",
                    Author = "Match Reporter",
                    Category = "Men's Team",
                    PublishedDate = DateTime.Now.AddDays(-3),
                    ViewCount = 890,
                    ImageUrl = "/images/mens-victory.jpg"
                },
                new NewsItem
                {
                    Id = 3,
                    Title = "Youth Academy Success Stories",
                    Excerpt = "Young talents showcase exceptional skills in recent tournaments.",
                    Content = "Our youth academy continues to produce exceptional talent. Recent tournaments have highlighted the skills and dedication of our young players, with several receiving recognition from national selectors.",
                    Author = "Youth Coach",
                    Category = "Youth Team",
                    PublishedDate = DateTime.Now.AddDays(-5),
                    ViewCount = 567,
                    ImageUrl = "/images/youth-success.jpg"
                },
                new NewsItem
                {
                    Id = 4,
                    Title = "New Training Facility Opens",
                    Excerpt = "State-of-the-art facility enhances team preparation capabilities.",
                    Content = "The new training facility features cutting-edge equipment and technology to help our teams prepare for competitions. The facility includes modern gym equipment, recovery rooms, and tactical analysis centers.",
                    Author = "Facility Manager",
                    Category = "General",
                    PublishedDate = DateTime.Now.AddDays(-7),
                    ViewCount = 1100,
                    ImageUrl = "/images/new-facility.jpg"
                }
            };
        }

        private List<MatchFixture> GetUpcomingMatches()
        {
            return new List<MatchFixture>
            {
                new MatchFixture
                {
                    Id = 1,
                    HomeTeam = "Our Team",
                    AwayTeam = "City Rivals",
                    MatchDate = DateTime.Now.AddDays(7),
                    Venue = "Home Stadium",
                    MatchType = "League Championship"
                },
                new MatchFixture
                {
                    Id = 2,
                    HomeTeam = "Regional Champions",
                    AwayTeam = "Our Team",
                    MatchDate = DateTime.Now.AddDays(14),
                    Venue = "Away Ground",
                    MatchType = "Cup Semi-Final"
                }
            };
        }

        private List<NewsItem> GetMensNews()
        {
            return new List<NewsItem>
            {
                new NewsItem
                {
                    Id = 5,
                    Title = "ჭაბუკთა 'ა' ლიგა | 'ლელომ' ტიტული უმძიმეს ბრძოლაში დაიცვა",
                    Excerpt = "ბოლო 10 წლის მანძილზე უფროსი ასაკის ჭაბუკ მორაგბეთა პირველობის ტიტულის მფლობელს 'აია'-'ლელოს' რიგით მე-8 დაპირისპირება არკვევდა.",
                    Content = "ბოლო 10 წლის მანძილზე უფროსი ასაკის ჭაბუკ მორაგბეთა პირველობის ტიტულის მფლობელს 'აია'-'ლელოს' რიგით მე-8 დაპირისპირება (მათ შორის ფინალში მეოთხედ) არკვევდა. აღნიშნულ პერიოდში დიდ დიღმელები 6-ჯერ გახდნენ ჩემპიონები (ერთხელ ფინალში 'ხვამლს' მოუგეს), 'აიამ' კი ტიტულის მოპოვება 2-ჯერ მოახერხა.\n\nუკვე მრავალი წელია, რაც 'ლელო' საქართველოს ახალგაზრდული და ეროვნული ნაკრების მთავარ დონორს წარმოადგენს. ქართული რაგბის ბერმუხა ბათუ (ვასილ) კევლიშვილის დიდი ძალისხმევითა და თაოსნობით, 'ლელოს' რაგბის აკადემიაში მიმდინარე გამართულმა, საათივით აწყობილმა, უამრავი ინოვაციით გაჯერებულმა საწვრთნელო პროცესმა დიდ დიღმელებს ჭაბუკ მორაგბეთა ორივე ასაკის პირველობებზე პრაქტიკულად ჰეგემონია დაამყარებინა.\n\n2 კვირის წინ, სამხრეთ აფრიკის 20 წლამდე ნაკრებთან გამართულ ამხანაგურ შეხვედრებში საქართველოს ახალგაზრდული ნაკრების დამრიგებელმა ლადო კილასონიამ სამონაწილეოდ 'ლელოს' 10 მორაგბეს უხმო, რომელთაც 'ლელოს' აკადემიის აღზრდილი არაერთი ლეგიონერიც შეემათ.",
                    Author = "სპორტული რეპორტიორი",
                    Category = "Youth Team",
                    PublishedDate = DateTime.Now.AddDays(-2),
                    ViewCount = 1850,
                    ImageUrl = "https://hebbkx1anhila5yf.public.blob.vercel-storage.com/4bebcd1a-e285-44dd-9d18-e67be8b94575.jpg-lPuPFwmePbLuJFxxjut63NadgkFNnw.jpeg"
                },
                new NewsItem
                {
                    Id = 6,
                    Title = "ლელო ჭაბუკთა \"ა\" ლიგის 7 კაცა ტურნირის გამარჯვებულია",
                    Excerpt = "12 აპრილს ლოკომოტივის ბაზაზე გაიმართა ჭაბუკთა \"ა\" ლიგის 7 კაცა ტურნირი სადაც გამარჯვებული, საქართველოს ჩემპიონი ხორბალაძე-შანიძის გუნდმა გახდა.",
                    Content = "12 აპრილს ლოკომოტივის ბაზაზე გაიმართა ჭაბუკთა \"ა\" ლიგის 7 კაცა ტურნირი სადაც გამარჯვებული, საქართველოს ჩემპიონი ხორბალაძე-შანიძის გუნდმა გახდა.",
                    Author = "ტურნირის ორგანიზატორები",
                    Category = "Youth Team",
                    PublishedDate = DateTime.Now.AddDays(-4),
                    ViewCount = 920,
                    ImageUrl = "https://hebbkx1anhila5yf.public.blob.vercel-storage.com/1fd63848-f6b3-4c77-9efa-9cff3663dc6c.jpg-CqcaMUcbbEF3vXtVeUoF0xFPDleh0O.jpeg"
                },
                new NewsItem
                {
                    Id = 7,
                    Title = "ლელო ესპუართა ლიგის ჩემპიონია",
                    Excerpt = "3 მაისს, ავჭალის სარაგბო სტადიონზე ესპუართა ლიგის ფინალური შეხვედრა \"ბათუმთან\" გვქონდა სადაც მეტოქე ანგარიშით 38:20 დავამარცხეთ.",
                    Content = "3 მაისს, ავჭალის სარაგბო სტადიონზე ესპუართა ლიგის ფინალური შეხვედრა \"ბათუმთან\" გვქონდა სადაც მეტოქე ანგარიშით 38:20 დავამარცხეთ და ესპუართა ლიგის ჩემპიონობა მინიმუმ ერთი წლით გავიხანგრძლივეთ.\n\nესპუართა ლიგის ფინალში უფროსებთან ერთად მონაწილეობა მიიღეს ახალგაზრდა მორაგბეებმაც რომლებიც მომავალი წლიდან კაცთა ლიგაში იასპარეზებენ.",
                    Author = "კლუბის ადმინისტრაცია",
                    Category = "General",
                    PublishedDate = DateTime.Now.AddDays(-6),
                    ViewCount = 1340,
                    ImageUrl = "https://hebbkx1anhila5yf.public.blob.vercel-storage.com/a7818084-195b-47f1-b81d-988d070f9d7d.jpg-2XJwiAEI3Ai6oRta4QmmPa1LY1SYjU.jpeg"
                }
            };
        }

        private List<MatchFixture> GetMensMatches()
        {
            return new List<MatchFixture>
            {
                new MatchFixture
                {
                    Id = 3,
                    HomeTeam = "Our Men's Team",
                    AwayTeam = "Championship Contenders",
                    MatchDate = DateTime.Now.AddDays(10),
                    Venue = "Home Stadium",
                    MatchType = "League Decider"
                }
            };
        }

        private List<NewsItem> GetWomensNews()
        {
            return new List<NewsItem>
            {
                new NewsItem
                {
                    Id = 8,
                    Title = "Women's Team Reaches Championship Final",
                    Excerpt = "Outstanding performance throughout the season leads to championship final appearance.",
                    Author = "Women's Coach",
                    Category = "Women's Team",
                    PublishedDate = DateTime.Now.AddDays(-1),
                    ViewCount = 1500,
                    ImageUrl = "/images/womens-final.jpg"
                }
            };
        }

        private List<MatchFixture> GetWomensMatches()
        {
            return new List<MatchFixture>
            {
                new MatchFixture
                {
                    Id = 4,
                    HomeTeam = "Our Women's Team",
                    AwayTeam = "League Leaders",
                    MatchDate = DateTime.Now.AddDays(5),
                    Venue = "Championship Stadium",
                    MatchType = "Championship Final"
                }
            };
        }

        private List<NewsItem> GetYouthNews()
        {
            return new List<NewsItem>
            {
                new NewsItem
                {
                    Id = 9,
                    Title = "Youth Academy Wins Regional Tournament",
                    Excerpt = "Young talents showcase exceptional skills in regional youth tournament victory.",
                    Author = "Youth Development",
                    Category = "Youth Team",
                    PublishedDate = DateTime.Now.AddDays(-3),
                    ViewCount = 650,
                    ImageUrl = "/images/youth-tournament.jpg"
                }
            };
        }
    }
}