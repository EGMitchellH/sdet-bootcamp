import HomePage from "../pages/saucedemo/answers/homePage";
import ProductsOverviewPage from "../pages/saucedemo/answers/productsOverviewPage";

// describe('Answers 03 - after', () => {
//
//     /**
//      * TODO: refactor the following three tests into a single, parameterized test
//      */
//     [
//         'standard_user',
//         'problem_user',
//         'visual_user'
//     ].forEach((username) => {
//
//         it(`should successfully log in the ${username}`, () => {
//
//             new HomePage()
//                 .visit()
//                 .loginAs(username, 'secret_sauce')
//
//             new ProductsOverviewPage().getLinkToBackpack().should('be.visible')
//         })
//     })
// })

describe('Answers 03 - after - with username and password parameterized', () => {

    /**
     * TODO: (EXTRA) usually, the password also varies from one user to the next.
     *   Can you figure out how to also parameterize that? Feel free to use Google,
     *   StackOverflow, ChatGPT or any other acceptable source to find an answer.
     */
    [
        {
            username: 'standard_user',
            password: 'secret_sauce'
        },
        {
            username: 'problem_user',
            password: 'secret_sauce'
        },
        {
            username: 'visual_user',
            password: 'secret_sauce'
        }
    ]
    .forEach((credentials) => {

        it(`should successfully log in with username ${credentials.username} and password ${credentials.password}`, () => {

            new HomePage()
                .visit()
                .loginAs(credentials.username, credentials.password)

            new ProductsOverviewPage().getLinkToBackpack().should('be.visible')
        })
    })
})
