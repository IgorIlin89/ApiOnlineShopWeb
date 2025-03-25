using ApiUser.Domain;
using FluentMigrator;

namespace ApiUser.Migrations;

[Migration(202408171100, "Initial")]
public class Initial : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table("User")
        .WithColumn(nameof(User.Id)).AsInt32().NotNullable().Identity().PrimaryKey()
        .WithColumn("EMail").AsString(100).NotNullable()
        .WithColumn("GivenName").AsString(100).NotNullable()
        .WithColumn("Surname").AsString(100).NotNullable()
        .WithColumn("Age").AsInt32().NotNullable()
        .WithColumn("Country").AsString(100).NotNullable()
        .WithColumn("Street").AsString(100).NotNullable()
        .WithColumn("City").AsString(100).NotNullable()
        .WithColumn("HouseNumber").AsInt32().NotNullable()
        .WithColumn("PostalCode").AsInt32().NotNullable()
        .WithColumn("Password").AsString().NotNullable();
    }
}