using Builder.Create;
using Builder.Options;
using Options = Builder.Options.Options;
using Object = Builder.Create.Object;

namespace Debug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Project project = new Project(new Options("Example Project", new Builder.Build.StageSize() { height = 1080, width = 1080 })); // create project
            
            Scene scene = new Scene("Scene Name"); // create scene

            Object @object = new Object("Object Name",50,50,1,"Textbox Text (Optional)"); // create text object

            Rule rule = new Rule(6000); // create new rule of type 6000
            Datum dat = new Datum { Type = 7000, Block_class = "operator", Description = "When Game Starts" }; // rule datum
            rule.Parameters.Add(new Parameter { Datum = dat, Value = "", Key = "", DefaultValue = "", Type = 52 }); // create a parameter and put the datum in it, then put parameter into parameter list

            Ability ability = new Ability("Ability Name"); // create ability

            Block block = new Block("method", 40, "Set Text"); // create block
            block.Parameters.Add(new Parameter { Value = "New Text", Key = "to" }); // first param of block
            block.Parameters.Add(new Parameter { Value = "HSB(0,0,0)", Key = "color", Type = 44 }); // second param of block
            
            ability.Blocks.Add(block); // add block to ability
            rule.Ability = ability; // add ability to rule
            @object.Rules.Add(rule); // add rule to object
            scene.Objects.Add(@object); // add object to scene
            project.Scenes.Add(scene); // add scene to project

            Console.WriteLine(project.ToJsonString());
            Console.ReadLine();
        }
    }
}