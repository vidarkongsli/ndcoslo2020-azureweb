using System.Diagnostics.CodeAnalysis;
using Kongsli.Ndc2020.Jokes.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Kongsli.Ndc2020.Jokes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class ScienceJokesController : ControllerBase
    {
        [HttpGet]
        public string Get() => ScienceJokes.PickRandomElement();

        private static readonly string[] ScienceJokes = {
            "Q: What would you call a funny element? A: He he he (helium helium helium)",
            "Q: Why does a burger have less energy than a steak? A: Because it's in its ground state.",
            "Q: How often do you like jokes about elements? A: Periodically",
            "A photon checks into a hotel, where a bellhop asks where its suitcase is. The photon replies, -I didn’t bring any luggage. I’m traveling light.",
            "Q: How many general-relativity theoretists does it take to change a light bulb? A: Two. One to hold the bulb and one to rotate space.",
            "Q: Why can't you trust an atom? A: They make up everything.",
            "Q: Why can’t you take electricity to social outings? A: Because it doesn’t know how to conduct itself.",
            @"A neutron walks into a bar and asks, ""How much for a whiskey?"" The bartender smiles and says, ""For you, no charge.""",
            "Q: Why didn't the sun go to college? A: Because it already had a million degrees!",
            "Q: What do planets like to read? A: Comet books!",
            "Q. Why couldn't the astronaut book a room on the moon? A. It was full!",
            "Q. What do scientists use to freshen their breath? A. Experi-mints!",
            @"Q. What does Earth say to tease the other planets? A. ""You guys have no life.""",
            "Q. How do Earth, Saturn, and Neptune organize a party? A. They planet.",
            "In 1905, Albert Einstein published a theory about space. And it was about time.",
            "Q. Why do people make bad chemistry jokes? A. Because all the good ones Argon.",
            "Q. What did the astronomer's friends do after he didn't win the Nobel Prize? A. They gave him a constellation prize.",
            "Q. Want to hear a Sodium joke? A. Na.",
            "Q. What did Neil Armstrong do after he stepped on Buzz Aldrin's toe? A. He Apollo-gized.",
            "Want to hear a Potassium joke? K.",
            "Did you hear about the chemist who was reading a book about helium? He couldn't put it down!",
            "What did the beach say when the tide came in? ... Long time no sea.",
            @"Atom 1: ""I think I've lost an electron."" Atom 2: ""Are you sure?"" Atom 1: ""I'm positive.""",
            "Q: Why are chemists great for solving problems? A: They have all the solutions.",
            "When she told me I was average, she was just being mean.",
            "Q: If H2O is the formula for water, what is the formula for ice? A: H2O cubed",
            "Q: What did their parents say when they heard that Oxygen and Magnesium were going to get married? A: OMg",
            "Once I told a Chemistry joke. There was no Reaction."
        };
    }
}