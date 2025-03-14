class RequestLoanPage {

    requestLoan(amount, downPayment, fromAccountId) {
        cy.get('input#amount').type(amount)
        cy.get('input#downPayment').type(downPayment)
        cy.get('select#fromAccountId').select(fromAccountId)
        cy.get('[value="Apply Now"]').click()
    }

    getResult() {
        return cy.get('td#loanStatus')
    }
}

export default RequestLoanPage