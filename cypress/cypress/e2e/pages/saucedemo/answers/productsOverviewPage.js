class ProductsOverviewPage {

    addBackpackToCart() {
        cy.get('a#item_4_title_link > div').click()
        cy.get('button#add-to-cart').click()
        return this
    }

    gotoShoppingCart() {
        cy.get('span.shopping_cart_badge').click()
    }

    getLinkToBackpack() {
        return cy.get('a#item_4_title_link > div')
    }
}

export default ProductsOverviewPage