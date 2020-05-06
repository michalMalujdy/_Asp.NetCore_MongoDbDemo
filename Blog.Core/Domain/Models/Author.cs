namespace Blog.Core.Domain.Models
{
    public class Author : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullNameUpperCased { get; set; }

        public void SetNames(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullNameUpperCased = $"{FirstName?.ToUpperInvariant()} {LastName?.ToUpperInvariant()}".Trim();
        }
    }
}