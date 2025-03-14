import SideMenu from "./components/sideMenu";

class AccountsOverviewPage {

    constructor() {
        this.sideMenu = new SideMenu()
    }

    selectRequestLoan() {
        this.sideMenu.selectRequestLoan()
    }

    getSideMenuHeader() {
        return cy.get('h2')
    }
}

export default AccountsOverviewPage