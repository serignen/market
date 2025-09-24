using System.ComponentModel.DataAnnotations;

namespace MarketApp.Models;

/// <summary>
/// Represents a software asset with license and user information
/// </summary>
public class SoftwareAsset
{
    /// <summary>
    /// Unique identifier for the software asset
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// First name of the license holder
    /// </summary>
    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Last name of the license holder
    /// </summary>
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Email address of the license holder
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Type of application/software
    /// </summary>
    [Required(ErrorMessage = "Application type is required")]
    [StringLength(100, ErrorMessage = "Application type cannot exceed 100 characters")]
    public string ApplicationType { get; set; } = string.Empty;

    /// <summary>
    /// Date when the license expires
    /// </summary>
    [Required(ErrorMessage = "License expiration date is required")]
    [DataType(DataType.Date)]
    public DateTime LicenseExpirationDate { get; set; }

    /// <summary>
    /// Date when the license subscription started
    /// </summary>
    [Required(ErrorMessage = "License subscription date is required")]
    [DataType(DataType.Date)]
    public DateTime LicenseSubscriptionDate { get; set; }

    /// <summary>
    /// Company name associated with the license
    /// </summary>
    [Required(ErrorMessage = "Company name is required")]
    [StringLength(100, ErrorMessage = "Company name cannot exceed 100 characters")]
    public string Company { get; set; } = string.Empty;

    /// <summary>
    /// Company website URL
    /// </summary>
    [Url(ErrorMessage = "Please enter a valid URL")]
    public string? CompanyUrl { get; set; }

    /// <summary>
    /// Price of the software license
    /// </summary>
    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    /// <summary>
    /// Full name property for display purposes
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";

    /// <summary>
    /// Indicates if the license is expired
    /// </summary>
    public bool IsExpired => LicenseExpirationDate < DateTime.Today;

    /// <summary>
    /// Days until license expires (negative if already expired)
    /// </summary>
    public int DaysUntilExpiration => (LicenseExpirationDate - DateTime.Today).Days;
}
