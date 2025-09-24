using MarketApp.Models;

namespace MarketApp.Services;

/// <summary>
/// Service for managing software assets with in-memory persistence
/// </summary>
public class AssetService
{
    private readonly List<SoftwareAsset> _assets = new();
    private int _nextId = 1;

    /// <summary>
    /// Initialize the service with sample data
    /// </summary>
    public AssetService()
    {
        // Add some sample data for demonstration
        AddSampleData();
    }

    /// <summary>
    /// Get all software assets
    /// </summary>
    /// <returns>List of all software assets</returns>
    public Task<List<SoftwareAsset>> GetAllAssetsAsync()
    {
        return Task.FromResult(_assets.ToList());
    }

    /// <summary>
    /// Get a software asset by ID
    /// </summary>
    /// <param name="id">Asset ID</param>
    /// <returns>Software asset or null if not found</returns>
    public Task<SoftwareAsset?> GetAssetByIdAsync(int id)
    {
        var asset = _assets.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(asset);
    }

    /// <summary>
    /// Create a new software asset
    /// </summary>
    /// <param name="asset">Asset to create</param>
    /// <returns>Created asset with assigned ID</returns>
    public Task<SoftwareAsset> CreateAssetAsync(SoftwareAsset asset)
    {
        asset.Id = _nextId++;
        _assets.Add(asset);
        return Task.FromResult(asset);
    }

    /// <summary>
    /// Update an existing software asset
    /// </summary>
    /// <param name="asset">Asset to update</param>
    /// <returns>Updated asset or null if not found</returns>
    public Task<SoftwareAsset?> UpdateAssetAsync(SoftwareAsset asset)
    {
        var existingAsset = _assets.FirstOrDefault(a => a.Id == asset.Id);
        if (existingAsset == null)
            return Task.FromResult<SoftwareAsset?>(null);

        var index = _assets.IndexOf(existingAsset);
        _assets[index] = asset;
        return Task.FromResult<SoftwareAsset?>(asset);
    }

    /// <summary>
    /// Delete a software asset by ID
    /// </summary>
    /// <param name="id">ID of asset to delete</param>
    /// <returns>True if deleted, false if not found</returns>
    public Task<bool> DeleteAssetAsync(int id)
    {
        var asset = _assets.FirstOrDefault(a => a.Id == id);
        if (asset == null)
            return Task.FromResult(false);

        _assets.Remove(asset);
        return Task.FromResult(true);
    }

    /// <summary>
    /// Get assets that are expiring soon (within 30 days)
    /// </summary>
    /// <returns>List of assets expiring soon</returns>
    public Task<List<SoftwareAsset>> GetAssetsExpiringSoonAsync()
    {
        var expiringSoon = _assets.Where(a => a.DaysUntilExpiration <= 30 && a.DaysUntilExpiration >= 0).ToList();
        return Task.FromResult(expiringSoon);
    }

    /// <summary>
    /// Add sample data for demonstration purposes
    /// </summary>
    private void AddSampleData()
    {
        var sampleAssets = new List<SoftwareAsset>
        {
            new SoftwareAsset
            {
                Id = _nextId++,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                ApplicationType = "Microsoft Office 365",
                LicenseExpirationDate = DateTime.Today.AddMonths(6),
                LicenseSubscriptionDate = DateTime.Today.AddYears(-1),
                Company = "Contoso Corporation",
                CompanyUrl = "https://www.contoso.com",
                Price = 99.99m
            },
            new SoftwareAsset
            {
                Id = _nextId++,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                ApplicationType = "Adobe Creative Suite",
                LicenseExpirationDate = DateTime.Today.AddDays(15),
                LicenseSubscriptionDate = DateTime.Today.AddMonths(-8),
                Company = "Design Studio Ltd",
                CompanyUrl = "https://www.designstudio.com",
                Price = 239.99m
            },
            new SoftwareAsset
            {
                Id = _nextId++,
                FirstName = "Bob",
                LastName = "Wilson",
                Email = "bob.wilson@example.com",
                ApplicationType = "JetBrains IntelliJ IDEA",
                LicenseExpirationDate = DateTime.Today.AddMonths(3),
                LicenseSubscriptionDate = DateTime.Today.AddMonths(-9),
                Company = "Tech Solutions Inc",
                CompanyUrl = "https://www.techsolutions.com",
                Price = 199.00m
            }
        };

        _assets.AddRange(sampleAssets);
    }
}
