namespace NIX.XPath;

public class ShopPageLocators
{
    // Cart
    private readonly string CartLinkXpath = "//header[@id='header']//a[@href='/view_cart']";
    private readonly string CartLinkCss = "#header a[href='/view_cart']";

    // Dress category
    private readonly string DressLinkXpath = "//div[@id='Women']//a[@href='/category_products/1']";
    private readonly string DressLinkCss = "#Women a[href='/category_products/1']";

    // Mast & Harbour
    private string BrandCountLocatorXpath(string brandName) => $"//a[contains(@href, '/brand_products/{brandName}')]/span[@class='pull-right']";
    private string BrandCountLocatorCss(string brandName) => $"a[href*='/brand_products/{brandName}'] span.pull-right";

    // Add to cart - static (always visible, inside .productinfo, scoped to the main features_items grid to exclude the Recommended items carousel)
    private string AddToCartStaticXpath(string productId) => $"//div[@class='features_items']//div[@class='productinfo text-center']//a[@data-product-id='{productId}']";
    private string AddToCartStaticCss(string productId) => $".features_items .productinfo a[data-product-id='{productId}']";

    // Add to cart - overlay (visible only on hover, inside .product-overlay)
    private string AddToCartOverlayXpath(string productId) => $"//div[@class='product-overlay']//a[@data-product-id='{productId}']";
    private string AddToCartOverlayCss(string productId) => $".product-overlay a[data-product-id='{productId}']";

    // View Product (static, inside the .choose div)
    private string ViewProductXpath(string productId) => $"//div[@class='choose']//a[@href='/product_details/{productId}']";
    private string ViewProductCss(string productId) => $".choose a[href='/product_details/{productId}']";

    // Subscription email input
    private readonly string SubscribeEmailXpath = "//input[@id='susbscribe_email']";
    private readonly string SubscribeEmailCss = "#susbscribe_email";

    // Footer copyright text
    private readonly string FooterCopyrightXpath = "//div[@class='footer-bottom']//p[@class='pull-left']";
    private readonly string FooterCopyrightCss = ".footer-bottom p.pull-left";

    // Scroll to top arrow
    private readonly string ScrollUpXpath = "//a[@id='scrollUp']";
    private readonly string ScrollUpCss = "#scrollUp";
}