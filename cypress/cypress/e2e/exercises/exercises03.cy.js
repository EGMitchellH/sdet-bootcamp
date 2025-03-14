import HomePage from "../pages/saucedemo/answers/homePage";
import ProductsOverviewPage from "../pages/saucedemo/answers/productsOverviewPage";

describe('Exercises 03 - before', () => {

    /**
     * TODO: refactor the following three tests into a single, parameterized test
     */
    [
        ['standard_user', 'secret_sauce'],
        ['problem_user', 'secret_sauce'],
        ['visual_user', 'secret_sauce']
    ].forEach((user) => 
        {
        it(`should successfully log in ${user}`, () => {
            new HomePage()  
                .visit()
                .loginAs(user[0], user[1])

            new ProductsOverviewPage().getLinkToBackpack().should('be.visible')
        })
    })

})