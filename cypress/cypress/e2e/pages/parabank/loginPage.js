class LoginPage {

    visit() {
        cy.visit('https://parabank.parasoft.com')
        return this
    }

    loginAs(username, password) {
        cy.get('[name="username"]').type(username)
        cy.get('[name="password"]').type(password)
        cy.get('[value="Log In"]').click()
    }
}

export default LoginPage