Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports System.Threading

Module AutoInventory
    Public Sub RunAutomationTask()
        Dim formInstance As Form1 = DirectCast(Application.OpenForms("Form1"), Form1)

        ' Initialize Chrome browser with the selected user data directory
        Dim options As New ChromeOptions()
        options.AddArgument("--user-data-dir=" & formInstance.userDataDir)
        options.AddArgument("--profile-directory=Default")
        options.AddArgument("--remote-debugging-port=9222")
        options.AddArgument("--no-sandbox")
        options.AddArgument("--disable-dev-shm-usage")
        options.AddArgument("--ignore-certificate-errors")

        formInstance.driver = New ChromeDriver(options)

        Try
            ' Open the target website
            formInstance.Log("Selenium Bot: Navigating to the website.", Color.Blue)
            formInstance.driver.Navigate().GoToUrl("https://app.extensiv.com/3pl-warehouse-manager")
            formInstance.Log("Selenium Bot: Opened the website.", Color.Green)

            ' Wait for the page to load completely
            Thread.Sleep(4000) ' Wait for 4 seconds

            ' Switch to the iframe if the "Inventory" button is inside one
            Try
                Dim iframe As IWebElement = formInstance.driver.FindElement(By.XPath("//iframe"))
                formInstance.driver.SwitchTo().Frame(iframe)
                formInstance.Log("Selenium Bot: Switched to iframe.", Color.Green)
            Catch ex As NoSuchElementException
                formInstance.Log("Selenium Bot: No iframe found. Continuing without switching to iframe.", Color.Orange)
            End Try

            ' Click the "Inventory" button by its data-wms-selector attribute
            Try
                Dim wait As New WebDriverWait(formInstance.driver, TimeSpan.FromSeconds(10))
                Dim inventoryButton As IWebElement = wait.Until(Function(d) d.FindElement(By.XPath("//a[@data-wms-selector='inventory_MainMenu']")))
                formInstance.Log("Selenium Bot: Found the Inventory button.", Color.Green)
                inventoryButton.Click()
                formInstance.Log("Selenium Bot: Clicked the Inventory button.", Color.Green)
            Catch ex As NoSuchElementException
                formInstance.Log("Selenium Bot: Inventory button not found. " & ex.Message, Color.Red)
                Return
            Catch ex As Exception
                formInstance.Log("Selenium Bot: Error clicking Inventory button. " & ex.Message, Color.Red)
                Return
            End Try

            ' Wait for the submenu to appear
            Thread.Sleep(2000)

            ' Click the "Manage Inventory" button by its data-wms-selector attribute
            Try
                Dim manageInventoryButton As IWebElement = formInstance.driver.FindElement(By.XPath("//a[@data-wms-selector='manageInventory_SubMenu_beta']"))
                formInstance.Log("Selenium Bot: Found the Manage Inventory button.", Color.Green)
                manageInventoryButton.Click()
                formInstance.Log("Selenium Bot: Clicked the Manage Inventory button.", Color.Green)
            Catch ex As NoSuchElementException
                formInstance.Log("Selenium Bot: Manage Inventory button not found. " & ex.Message, Color.Red)
                Return
            Catch ex As Exception
                formInstance.Log("Selenium Bot: Error clicking Manage Inventory button. " & ex.Message, Color.Red)
                Return
            End Try

            ' Wait for the inventory page to load
            Thread.Sleep(2000) ' Adjust the sleep time if necessary
            formInstance.Log("Selenium Bot: Waiting for inventory page to load.", Color.Blue)

            ' Click the Refresh button
            Try
                Dim refreshButton As IWebElement = formInstance.driver.FindElement(By.CssSelector("div.wms_toolbar_button_text"))
                refreshButton.Click()
                formInstance.Log("Selenium Bot: Clicked the Refresh button.", Color.Green)
            Catch ex As NoSuchElementException
                formInstance.Log("Selenium Bot: Refresh button not found. " & ex.Message, Color.Red)
                Return
            Catch ex As Exception
                formInstance.Log("Selenium Bot: Error clicking Refresh button. " & ex.Message, Color.Red)
                Return
            End Try

            ' Wait for 5 seconds after clicking Refresh
            Thread.Sleep(5000)
            formInstance.Log("Selenium Bot: Waited 5 seconds after clicking Refresh.", Color.Blue)

            ' Wait for the "Click Here" link to appear and click it
            Try
                Dim wait As New WebDriverWait(formInstance.driver, TimeSpan.FromSeconds(20)) ' Increase the wait time if needed
                Dim clickHereLink As IWebElement = wait.Until(Function(d) d.FindElement(By.CssSelector("a.wms-click-here")))
                clickHereLink.Click()
                formInstance.Log("Selenium Bot: Clicked the 'Click Here' link.", Color.Green)
            Catch ex As NoSuchElementException
                formInstance.Log("Selenium Bot: 'Click Here' link not found. " & ex.Message, Color.Red)
                Return
            Catch ex As Exception
                formInstance.Log("Selenium Bot: Error clicking 'Click Here' link. " & ex.Message, Color.Red)
                Return
            End Try

            ' Wait for the data to load
            Thread.Sleep(17000) ' Adjust the sleep time if necessary
            formInstance.Log("Selenium Bot: Waiting for data to load.", Color.Blue)

            ' Click the Options button
            Try
                Dim optionsButton As IWebElement = formInstance.driver.FindElement(By.CssSelector("span.virtual-grid-options"))
                optionsButton.Click()
                formInstance.Log("Selenium Bot: Clicked the Options button.", Color.Green)
            Catch ex As NoSuchElementException
                formInstance.Log("Selenium Bot: Options button not found. " & ex.Message, Color.Red)
                Return
            Catch ex As Exception
                formInstance.Log("Selenium Bot: Error clicking Options button. " & ex.Message, Color.Red)
                Return
            End Try

            ' Click the Export to Excel option
            Thread.Sleep(2000) ' Wait for the dropdown menu to appear
            Try
                Dim exportExcelButton As IWebElement = formInstance.driver.FindElement(By.CssSelector("li[data-wms-selector='GridManageInventoryBeta_exportExcelGrid']"))
                exportExcelButton.Click()
                formInstance.Log("Selenium Bot: Clicked the Export to Excel option.", Color.Green)

                ' Wait for 10 seconds to allow the download popup to appear
                Thread.Sleep(10000)
                formInstance.Log("Selenium Bot: Waited 10 seconds for download popup.", Color.Blue)
            Catch ex As NoSuchElementException
                formInstance.Log("Selenium Bot: Export to Excel option not found. " & ex.Message, Color.Red)
                Return
            Catch ex As Exception
                formInstance.Log("Selenium Bot: Error clicking Export to Excel option. " & ex.Message, Color.Red)
                Return
            End Try

        Catch ex As Exception
            formInstance.Log("Selenium Bot: Error - " & ex.Message, Color.Red)
        Finally
            formInstance.driver.Quit()
            formInstance.taskRunning = False
            formInstance.Log("Selenium Bot: Task completed.", Color.Blue)
        End Try
    End Sub
End Module
