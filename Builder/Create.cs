using Builder.Build;
using Builder.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.CodeDom.Compiler;
using System.Data;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Xml;
using Options = Builder.Options.Options;

namespace Builder.Create;

public class Project: IGetScene
{
    public Options.Options options { get; set; }
    //public Options.Options options { get { return _options; } set { _options = value; } }

    private List<Scene> _scenes;
    public List<Scene> Scenes {
        get {
            return _scenes;
        }
        set {
            _scenes = value;
        }
    }
    public Project(Options.Options options) //constructor
    {
        this.options = options;
        this._scenes = new List<Scene>();
    }
    public IGetScene GetScene
    {
        get { return (IGetScene)this; }
    }
    Scene IGetScene.FromName(string name)
    {
        for (int i = 0; i < _scenes.Count; i++)
        {
            if (_scenes[i].Name == name)
            {
                return _scenes[i];
            }
        }
        return null;
    }
}

public class Scene: IGetObject
{
    public Scene(string name) //constructor
    {
        this.Name = name;
        this._objects = new List<Object>();
    }

    public string Name { get; set; }
    public List<Object> _objects = new List<Object>();

    public List<Object> Objects
    {
        get
        {
            return _objects;
        }
        set
        {
            _objects = value;
            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].Parent = this;
            }
        }
    }

    public IGetObject GetObject
    {
        get { return (IGetObject)this; }
    }

    Object IGetObject.FromName(string name)
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if (_objects[i].Name == name)
            {
                return _objects[i];
            }
        }
        return null;
    }

    Object IGetObject.FromId(string id)
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if (_objects[i].Id == id)
            {
                return _objects[i];
            }
        }
        return null;
    }
}




public class Object: IGetRule
{
    public Object(string name, double x, double y, int type, string text = "", string filename = "text-object.png") //constructor
    {
        this.Id = Guid.NewGuid().ToString();
        this.Name = name;
        this.Text = text;
        this.X = x;
        this.Y = y;
        this.Filename = filename;
        this.Type = type;
        this._Rules = new List<Rule>();
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public string Text { get; set; }
    public string Filename { get; set; }
    public int Type { get; set; }

    public Scene Parent { get; set; }


    private List<Rule> _Rules { get; set; }

    public List<Rule> Rules
    {
        get
        {
            return _Rules;
        }
        set
        {
            _Rules = value;
            for (int i = 0; i < _Rules.Count; i++)
            {
                _Rules[i].Parent = this;
            }
        }
    }

    public IGetRule GetRule
    {
        get { return (IGetRule)this; }
    }

    Rule IGetRule.FromId(string id)
    {
        for (int i = 0; i < _Rules.Count; i++)
        {
            if (_Rules[i].Id == id)
            {
                return _Rules[i];
            }
        }
        return null;
    }
}







public class Rule
{
    public Rule(int ruleBlockType) //constructor
    {
        this.Id = Guid.NewGuid().ToString();
        this.RuleBlockType = ruleBlockType;
        this.Ability = null; // because it is only one, not a List<T>
    }

    public string Id { get; set; }
    public int RuleBlockType { get; set; }
    public Ability Ability {
        get
        {
            return _ability;
        }
        set
        {
            _ability = value;
            //_ability.Parent = this;
        } 
    }
    private Ability _ability { get; set; }
    public List<Parameter> Parameters = new List<Parameter>();
    public string Name { get; set; }
    public Object Parent { get; set; }
}




public class Ability
{
    public Ability(string name) //constructor
    {
        this.Id = Guid.NewGuid().ToString();
        this.Name = name;
        this.Blocks = new List<Block>();
    }

    public Ability() //constructor
    {
        this.Blocks = new List<Block>();
    }

    public double CreatedAt { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public Rule Parent;

    private List<Block> _Blocks { get; set; }

    public List<Block> Blocks
    {
        get
        {
            return _Blocks;
        }
        set
        {
            _Blocks = value;
            for (int i = 0; i < _Blocks.Count; i++)
            {
                _Blocks[i].Parent = this;
            }
        }
    }
}





public class Block
{
    public Block(string block_class, int type, string description = "") //constructor
    {
        this.Block_class = block_class;
        this.Type = type;
        this.Description = description;
    }

    public string Block_class { get; set; }
    public int Type { get; set; }
    public string Description { get; set; }
    public List<Parameter> Parameters = new List<Parameter>();
    public ControlScript ControlScript { get; set; }
    public ControlFalseScript ControlFalseScript { get; set; }
    public Ability Parent;
}


public class ControlFalseScript
{
    public Ability Ability = new Ability();
}

public class ControlScript
{
    public Ability Ability = new Ability();
}

public class CustomRule
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<string> Rules = new List<string>();
}

public class Datum
{
    public int Type { get; set; }
    public string Block_class { get; set; }
    public string Description { get; set; }
    public string HSTraitIDKey { get; set; }
    public int? HSTraitTypeKey { get; set; }
    //public List<Param> Params { get; set; }
    public List<Parameter> Params = new List<Parameter>();
    public int? HSTraitObjectParameterTypeKey { get; set; }
    public Variable Variable { get; set;}
}

public class EventParameter
{
    public string Id { get; set; }
    public int BlockType { get; set; }
    public string Description { get; set; }
}

//public class Param
//{
//    public string DefaultValue { get; set; }
//    public string Value { get; set; }
//    public string Key { get; set; }
//    public int Type { get; set; }
//    public Datum Datum { get; set; }
//    public Variable Variable { get; set; }
//}

public class Parameter
{
    public string DefaultValue { get; set; }
    public string Value { get; set; }
    public string Key { get; set; }
    //public Datum Datum { get { Console.WriteLine(MethodBase.GetCurrentMethod().Name.Substring(4)); return this._Datum; } set { this._Datum = value; } }
    public Datum Datum { get; set; }
    public int Type { get; set; }
}

public class Variable
{
    public Variable()
    {
        this.Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public string Name { get; set; }
    public Object Object { get; set; }
    public int Type { get; set; }
}


public interface IGetScene
{
    Scene FromName(string name);
}

public interface IGetObject
{
    Object FromName(string name);
    Object FromId(string name);
}

public interface IGetRule
{
    Rule FromId(string name);
}

public interface IGetAbility
{
    Ability FromId(string name);
}

public interface IGetBlock
{
    Block FromId(string name);
}

internal static class InternalMethods
{
    internal static List<TProp> GetProperties<T, TProp>(this IEnumerable<T> seq, Func<T, TProp> selector)
    {
        return seq.Select(selector).ToList();
    }
}

public static class Project_Ext
{
    public static string ToJsonString(this Project project)
    {
        Root root = new Root();

        for (int i = 0; i < project.Scenes.Count; i++)
        {
            Build.Scene scene = new Build.Scene();
            scene.name = project.Scenes[i].Name;
            scene.objects = project.Scenes[i].Objects.GetProperties(a => a.Id);
            root.scenes.Add(scene);

            for (int j = 0; j < project.Scenes[i].Objects.Count; j++)
            {
                Build.Object @object = new Build.Object();
                @object.text = project.Scenes[i].Objects[j].Text;
                @object.filename = project.Scenes[i].Objects[j].Filename;
                @object.name = project.Scenes[i].Objects[j].Name;
                @object.objectID = project.Scenes[i].Objects[j].Id;
                @object.type = project.Scenes[i].Objects[j].Type;
                @object.xPosition = project.Scenes[i].Objects[j].X.ToString();
                @object.yPosition = project.Scenes[i].Objects[j].Y.ToString();
                @object.rules = project.Scenes[i].Objects[j].Rules.GetProperties(a => a.Id);
                root.objects.Add(@object);

                for (int k = 0; k < project.Scenes[i].Objects[j].Rules.Count; k++)
                {
                    Build.Rule rule = new Build.Rule();
                    rule.id = project.Scenes[i].Objects[j].Rules[k].Id;
                    rule.name = project.Scenes[i].Objects[j].Rules[k].Name;
                    List<Build.Parameter> parameters = new List<Build.Parameter>();
                    for (int l = 0; l < project.Scenes[i].Objects[j].Rules[k].Parameters.Count; l++)
                    {
                        rule.parameters.Add(CreateParamToBuildParam(project.Scenes[i].Objects[j].Rules[k].Parameters[l]));
                    }
                    rule.abilityID = project.Scenes[i].Objects[j].Rules[k].Ability.Id;
                    rule.ruleBlockType = project.Scenes[i].Objects[j].Rules[k].RuleBlockType;
                    rule.objectID = project.Scenes[i].Objects[j].Id; // we could do it through the parent property but that can be changed by the user
                    root.rules.Add(rule);

                    Build.Ability ability = new Build.Ability();
                    ability.createdAt = 528310318.27146; // i dont even know what this measures :/
                    ability.abilityID = project.Scenes[i].Objects[j].Rules[k].Ability.Id;
                    ability.name = project.Scenes[i].Objects[j].Rules[k].Ability.Name;

                    for (int m = 0; m < project.Scenes[i].Objects[j].Rules[k].Ability.Blocks.Count; m++)
                    {
                        Build.Block block = new Build.Block();
                        block.block_class = project.Scenes[i].Objects[j].Rules[k].Ability.Blocks[m].Block_class;

                        if (project.Scenes[i].Objects[j].Rules[k].Ability.Blocks[m].ControlFalseScript != null)
                        {
                            Build.ControlFalseScript controlFalseScript = new Build.ControlFalseScript();
                            controlFalseScript.abilityID = project.Scenes[i].Objects[j].Rules[k].Ability.Blocks[m].ControlFalseScript.Ability.Id;
                            block.controlFalseScript = controlFalseScript;
                        }

                        if (project.Scenes[i].Objects[j].Rules[k].Ability.Blocks[m].ControlScript != null)
                        {
                            Build.ControlScript controlScript = new Build.ControlScript();
                            controlScript.abilityID = project.Scenes[i].Objects[j].Rules[k].Ability.Blocks[m].ControlScript.Ability.Id;
                            block.controlScript = controlScript;
                        }

                        block.description = project.Scenes[i].Objects[j].Rules[k].Ability.Blocks[m].Description;
                        block.type = project.Scenes[i].Objects[j].Rules[k].Ability.Blocks[m].Type;
                        for (int n = 0; n < project.Scenes[i].Objects[j].Rules[k].Ability.Blocks[m].Parameters.Count; n++)
                        {
                            block.parameters.Add(CreateParamToBuildParam(project.Scenes[i].Objects[j].Rules[k].Ability.Blocks[m].Parameters[n]));
                        }

                        ability.blocks.Add(block);
                    }
                    root.abilities.Add(ability);
                }
            }
        }

        root.baseObjectScale = project.options.baseObjectScale;
        root.title = project.options.title;
        root.filename = project.options.filename;
        root.fontSize = project.options.fontSize;
        root.version = project.options.version;
        root.stageSize = project.options.stageSize;
        root.remote_asset_urls = project.options.remote_asset_urls;
        root.traits = project.options.traits;
        root.customObjects = project.options.customObjects;
        root.eventParameters = project.options.eventParameters;

        var json = JsonConvert.SerializeObject(root, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }).ToString();
        return json;
    }

    private static Build.Parameter CreateParamToBuildParam(Create.Parameter parameters)
    {
        Build.Parameter @param = new Build.Parameter();
        param.value = parameters.Value;
        param.defaultValue = parameters.DefaultValue;
        param.type = parameters.Type;
        param.key = parameters.Key;


        if (parameters.Datum != null && parameters.Datum.Params != null)
        {
            param.datum = CreateDatumToBuildDatum(parameters.Datum);
            return param;
        }
        else
        {
            return param;
        }
    }

    private static Build.Datum CreateDatumToBuildDatum(Create.Datum _datum)
    {
        Build.Datum datum = new Build.Datum();
        if (_datum.Variable != null && _datum.Variable.Id != null)
        {
            datum.variable = _datum.Variable.Id;
        }
        datum.block_class = _datum.Block_class;
        datum.description = _datum.Description;
        datum.HSTraitIDKey = _datum.HSTraitIDKey;
        datum.HSTraitObjectParameterTypeKey = _datum.HSTraitObjectParameterTypeKey;
        datum.HSTraitTypeKey = _datum.HSTraitTypeKey;
        datum.type = _datum.Type;
        if (_datum.Params != null)
        {
            for (int i = 0; i < _datum.Params.Count; i++)
            {
                datum.@params.Add(CreateParamToBuildParam(_datum.Params[i]));
            }
            return datum;
        }
        else
        {
            return datum;
        }
    }
}