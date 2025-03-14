import LoginPage from "../pages/parabank/loginPage";
import AccountsOverviewPage from "../pages/parabank/accountsOverviewPage";
import RequestLoanPage from "../pages/parabank/requestLoanPage";

describe('Examples 02', () => {

    it('should successfully request a loan - before', () => {

        // Navigate to the ParaBank home page
        cy.visit('https://parabank.parasoft.com')

        // Log in
        cy.get('[name="username"]').type('john')
        cy.get('[name="password"]').type('demo')
        cy.get('[value="Log In"]').click()

        // Navigate to the 'Request Loan' page
        cy.get('[href="requestloan.htm"]').click()

        // Fill in the form
        cy.get('input#amount').type('10000')
        cy.get('input#downPayment').type('100')
        cy.get('select#fromAccountId').select('12345')
        cy.get('[value="Apply Now"]').click()

        // Verify that the result is 'Denied'
        cy.get('td#loanStatus')
            .should('be.visible')
            .should('have.text', 'Denied')
    })

    it('should successfully request a loan - after', () => {

        new LoginPage()
            .visit()
            .loginAs('john', 'demo')

        new AccountsOverviewPage()
            .selectRequestLoan()

        /**
         * TODO: which coding style do you prefer,
         *   separate method calls or chained method calls? Why?
         */
        const requestLoanPage = new RequestLoanPage()
        requestLoanPage.requestLoan('10000', '100', '12345')
        requestLoanPage.getResult()
            .should('be.visible')
            .should('have.text', 'Denied')
    })
})