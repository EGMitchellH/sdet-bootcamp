class SideMenu {

    selectRequestLoan() {
        cy.get('[href="requestloan.htm"]').click()
    }
}

export default SideMenu