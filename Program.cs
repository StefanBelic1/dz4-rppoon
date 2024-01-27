using System;

// Ovaj primjer je builder, obrazac stvaranja.
public class Permissions
{
    public string Admin { get; set; }
    public string User { get; set; }
    public string Manager { get; set; }
}


public interface IPermissionsBuilder
{
    void BuildAdmin();
    void BuildUser();
    void BuildManager();
    Permissions GetPermissions();
}

public class ConcretePermissionsBuilder : IPermissionsBuilder
{
    private Permissions _permissions = new Permissions();

    public void BuildAdmin()
    {
        _permissions.Admin = "Give all permissions";
    }

    public void BuildUser()
    {
        _permissions.User = "Give basic user permissions";
    }

    public void BuildManager()
    {
        _permissions.Manager = "Give create, edit, and view permissions";
    }

    public Permissions GetPermissions()
    {
        return _permissions;
    }
}

public class PermissionsDirector
{
    private IPermissionsBuilder _builder;

    public PermissionsDirector(IPermissionsBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructPermissions()
    {
        _builder.BuildAdmin();
        _builder.BuildUser();
        _builder.BuildManager();
    }
}

class Program
{
    static void Main()
    {
        IPermissionsBuilder builder = new ConcretePermissionsBuilder();
        PermissionsDirector director = new PermissionsDirector(builder);

        director.ConstructPermissions();
        Permissions permissions = builder.GetPermissions();

        Console.WriteLine("Admin: " + permissions.Admin);
        Console.WriteLine("User: " + permissions.User);
        Console.WriteLine("Manager: " + permissions.Manager);
    }
}