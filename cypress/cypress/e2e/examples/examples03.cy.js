import LoginPage from "../pages/parabank/loginPage";
import AccountsOverviewPage from "../pages/parabank/accountsOverviewPage";
import RequestLoanPage from "../pages/parabank/requestLoanPage";

describe('Examples 03 - before', () => {

    it('should successfully log in John', () => {

        new LoginPage()
            .visit()
            .loginAs('john', 'demo')

        new AccountsOverviewPage().getSideMenuHeader()
            .should('be.visible')
            .should('have.text', 'Account Services')
    })

    it('should successfully log in Bob', () => {

        new LoginPage()
            .visit()
            .loginAs('parasoft', 'demo')

        new AccountsOverviewPage().getSideMenuHeader()
            .should('be.visible')
            .should('have.text', 'Account Services')
    })
})

describe('Examples 03 - after', () => {

    [
        'john',
        'parasoft'
    ].forEach((username) => {

        it(`should successfully log in ${username}`, () => {

            new LoginPage()
                .visit()
                .loginAs(username, 'demo')

            new AccountsOverviewPage().getSideMenuHeader()
                .should('be.visible')
                .should('have.text', 'Account Services')
        })
    })
})
