# WebDriverUtility
Custom Selenium wrapper

## Getting Started

### Prerequisites

Probably will be needed to download Selenium.WebDriver from NuGet

```
Right click on project -> Manage NuGet Packages... -> Browse -> Selenium.WebDriver
```

### Installing

Download project, add to new solution, build and run.

### Little example

```
    SUtility sUtility = new SUtility(Browser.Chrome, hideConsole: true);
    sUtility.Action.Go2URL("https://example.com/");

    sUtility.Element.ById("userName").WriteText("userName");
    sUtility.Element.ById("submitBtn").Click();
    sUtility.Element.ById("password").WriteText("password");
    sUtility.Element.ById("submitBtn").Click();
    sUtility.Element.ById("someText").WriteText("Lorem Ipsum");
    sUtility.Element.ById("searchBtn").Click();
```

## Authors

* **SeM** - *Initial work* - [NeoSeM](https://github.com/NeoSeM)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
