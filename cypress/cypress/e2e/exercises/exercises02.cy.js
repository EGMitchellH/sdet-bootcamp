import HomePage from "../pages/saucedemo/exercises/homePage";
import ProductsOverviewPage from "../pages/saucedemo/exercises/productsOverviewPage";
import ShoppingCartPage from "../pages/saucedemo/exercises/shoppingCartPage";
import CheckoutPage from "../pages/saucedemo/exercises/checkoutPage";
import OrderConfirmationPage from "../pages/saucedemo/exercises/orderConfirmationPage";

describe('Exercises 02', () => {

    it('should order an item from the Sauce Demo store', () => {

        /**
         * TODO: Improve the login sequence code by using methods from the HomePage class.
         *   The methods have been defined and implemented for you already.
         */
        /*cy.visit('https://www.saucedemo.com')

        cy.get('#user-name').type('standard_user')
        cy.get('#password').type('secret_sauce')
        cy.get('#login-button').click()*/

        new HomePage()
            .visit('https://www.saucedemo.com')
            .loginAs('standard_user', 'secret_sauce')

        /**
         * TODO: Improve adding a product to the cart and going to the cart overview
         *   by using methods from the ProductsOverviewPage class.
         *   The methods have been defined and implemented for you already.
         */
        /*cy.get('a#item_4_title_link > div').click()
        cy.get('button#add-to-cart').click()
        cy.get('span.shopping_cart_badge').click()*/
        new ProductsOverviewPage()
            .addBackpackToCart()
            .gotoShoppingCart()

        /**
         * TODO: Improve starting the checkout process by using the correct
         *   method from the ShoppingCartPage class. The method has been defined
         *   for you already, but the right action(s) need(s) to be added still.
         */
        /*

        cy.get('input#first-name').type('Jane')
        cy.get('input#last-name').type('Doe')
        cy.get('input#postal-code').type('90210')
        cy.get('input#continue').click()
        cy.get('button#finish').click()*/
        new ShoppingCartPage()
            .gotoCheckout('Jane', 'Doe', 90210)


        /**
         * TODO: Create a new class  and add a method that returns
         *   the order confirmation message. Use that method instead of the direct call
         *   to cy.get() used here.
         *   Don't forget to import your new class here by adding it to the imports at
         *   the top of the file!
         */

        new OrderConfirmationPage().getConfirmationMessage()
            .should('be.visible')
            .should('have.text', 'Thank you for your order!')
    })
})