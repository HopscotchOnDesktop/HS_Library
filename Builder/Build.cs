using System.Data;
using System.Reflection.Metadata;

namespace Builder.Build;

public class Ability
{
    public double createdAt { get; set; }
    public List<Block> blocks = new List<Block> { };
    public string abilityID { get; set; }
    public string name { get; set; }
}

public class Badges
{
    public bool top_planter { get; set; }
}

public class Block
{
    public string block_class { get; set; }
    public int type { get; set; }
    public string description { get; set; }
    public List<Parameter> parameters = new List<Parameter> { };
    public ControlScript controlScript { get; set; }
    public ControlFalseScript controlFalseScript { get; set; }
}

public class ControlFalseScript
{
    public string abilityID { get; set; }
}

public class ControlScript
{
    public string abilityID { get; set; }
}

public class CustomRule
{
    public string id { get; set; }
    public string name { get; set; }
    public List<string> rules = new List<string> { };
}

public class Datum
{
    public int type { get; set; }
    public string block_class { get; set; }
    public string description { get; set; }
    public string HSTraitIDKey { get; set; }
    public int? HSTraitTypeKey { get; set; }
    //public List<Param> @params { get; set; }
    public List<Parameter> @params = new List<Parameter> { };
    public int? HSTraitObjectParameterTypeKey { get; set; }
    public string variable { get; set; }
}

public class EventParameter
{
    public string id { get; set; }
    public int blockType { get; set; }
    public string description { get; set; }
}

public class Object
{
    public string objectID { get; set; }
    public string xPosition { get; set; }
    public string text { get; set; }
    public string filename { get; set; }
    public int type { get; set; }
    public List<string> rules = new List<string> { };
    public string name { get; set; }
    public string yPosition { get; set; }
}

public class OriginalUser
{
    public string id { get; set; }
    public int avatar_type { get; set; }
    public string created_at { get; set; }
    public bool iphone_user { get; set; }
    public string nickname { get; set; }
    public Badges badges { get; set; }
}

public class Param
{
    public string defaultValue { get; set; }
    public string value { get; set; }
    public string key { get; set; }
    public int type { get; set; }
    public Datum datum { get; set; }
    public string variable { get; set; }
}

public class Parameter
{
    public string defaultValue { get; set; }
    public string value { get; set; }
    public string key { get; set; }
    public Datum datum { get; set; }
    public int type { get; set; }
}

public class Root
{
    //public List<CustomRule> customRules = new List<CustomRule> { };
    //public int baseObjectScale { get; set; }
    //public string author { get; set; }
    //public DateTime published_at { get; set; }
    //public string screenshot_url { get; set; }
    //public int fontSize { get; set; }
    //public List<object> customObjects = new List<object> { };
    //public DateTime deleted_at { get; set; }
    //public string filename { get; set; }
    //public int number_of_stars { get; set; }
    //public string text_object_label { get; set; }
    //public List<object> remote_asset_urls = new List<object> { };
    //public int version { get; set; }
    //public int play_count { get; set; }
    //public string uuid { get; set; }
    //public DateTime edited_at { get; set; }
    //public List<EventParameter> eventParameters = new List<EventParameter> { };
    //public bool in_moderation { get; set; }
    //public User user { get; set; }
    //public OriginalUser original_user { get; set; }
    //public StageSize stageSize { get; set; }
    //public List<Ability> abilities = new List<Ability> { };
    //public bool has_been_removed { get; set; }
    //public DateTime correct_published_at { get; set; }
    //public List<object> traits = new List<object> { };
    //public int user_id { get; set; }
    //public List<Scene> scenes = new List<Scene> { };
    //public List<Rule> rules = new List<Rule> { };
    //public List<Object> objects = new List<Object> { };
    //public List<Variable> variables = new List<Variable> { };
    //public string title { get; set; }
    //public int project_remixes_count { get; set; }
    //public int published_remixes_count { get; set; }
    //public int plants { get; set; }

    public int baseObjectScale { get; set; }
    public int fontSize { get; set; }
    public List<object> customObjects = new List<object> { };
    public string filename { get; set; }
    public List<object> remote_asset_urls = new List<object> { };
    public int version { get; set; }
    public List<EventParameter> eventParameters = new List<EventParameter> { };
    public StageSize stageSize { get; set; }
    public List<Ability> abilities = new List<Ability> { };
    public List<object> traits = new List<object> { };
    public List<Scene> scenes = new List<Scene> { };
    public List<Rule> rules = new List<Rule> { };
    public List<Object> objects = new List<Object> { };
    public List<Variable> variables = new List<Variable> { };
    public string title { get; set; }

    public bool HopscotchOnDesktop = true;
}

public class Rule
{
    public int ruleBlockType { get; set; }
    public string id { get; set; }
    public string abilityID { get; set; }
    public List<Parameter> parameters = new List<Parameter> { };
    public string name { get; set; }
    public string objectID { get; set; }
}

public class Scene
{
    public string name { get; set; }
    public List<string> objects = new List<string> { };
}

public class StageSize
{
    public int width { get; set; }
    public int height { get; set; }
}

public class User
{
    public int id { get; set; }
    public int avatar_type { get; set; }
    public string created_at { get; set; }
    public bool iphone_user { get; set; }
    public string nickname { get; set; }
    public Badges badges { get; set; }
}

public class Variable
{
    public string name { get; set; }
    public string objectIdString { get; set; }
    public int type { get; set; }
}