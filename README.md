# **CSIT327 Final Project - Group 1: JASS**

![Logo](https://user-images.githubusercontent.com/111829440/194299519-046dd6e0-1c7d-439e-a12b-a886b8a347ed.png)

## Topps Premium Coffee Shop Delivery
`Topps Premium Coffee Shop` is very happy to introduce to you our online-based ordering and delivery system!

Straightforward and easy-to-use, this WebAPI allows customers to easily navigate through a no-nonsense ordering and delivery system.

Just simply sign up for a membership, log in, and begin satisfying your caffeine cravings!

## System Database and WebAPI Overview

The system demonstrates the information management model of an online coffee shop's delivery web application. 
It is concerned with the user experience (UX) of customers who utilize the app to order items online.
Because of its aforementioned nature, this project focuses on two main entities: customers and their orders.

![Group1(JASS) - ERD](https://user-images.githubusercontent.com/111829440/196185405-876a9a09-9a49-41d2-80f0-f54ab0a1ed84.png)

### `Customer` and `Preferences`
A **customer** may have **preferences**; **preferences** are their ordering habits and tastes. 
This information is very helpful for the **barista/s**, and for the business as a whole, as it helps them to familiarize and form good relationships with the **customers**.

For example, a **customer** may like to order donut items most of the time, and may prefer to have their espresso black. 
Another customer may like their cappucino cold and iced, and a third customer might only order cake items.

Customers may place **orders**, explained below:

### `Orders`
**Order/s** include information about who (**barista/s**) made this order item, who (**customer**) ordered this, the included **product/s**, and **payment** details. This also serves as the bill for the customer.

A **product** has a name, product type, description, and a set price.

**Payments** serve as the customer's receipt of payment, and are assigned an auto-generated ID, an amount, and a date.

A **customer** may leave **reviews** and comments for their orders. This helps the shop to improve and perfect their business craft.

## Contributors
- Barcenilla, Adrian Jay
- Quijano, Sean Venz
- Leonor, Jie Ann
- Cuizon, Shane
