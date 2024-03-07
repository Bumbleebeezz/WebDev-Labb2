# WebDev-Labb2
# Planing for HandmadeApi

## Endpoints
### Products
| Path                   | Method | Request             | Response  | ResponseCodes |
| ---------------------- | ------ | ------------------- | --------- | ------------- |
| "/products"            | GET    | NONE                | Product[] | 200, 404      |
| "/products/{id}"       | GET    | int ID              | Product   | 200, 404      |
| "/products/{naem}"     | GET    | string Name         | Product   | 200, 404      |
| "/products/{Category}" | GET    | string Category     | Product   | 200, 404      |
|                        |        |                     |           |               |
| "/products"            | POST   | Product             | NONE      | 200, 400      |
|                        |        |                     |           |               |
| "/products/{id}"       | PATCH  | int ID, float Price | NONE      | 200, 400, 404 |
|                        |        |                     |           |               |
| "/products/{id}"       | DELETE | int ID              | NONE      | 200, 404      |

### Customers
| Path                   | Method | Request             |  Response  | ResponseCodes |
| ---------------------- | ------ | ------------------- | ---------- | ------------- |
| "/customers"           | GET    | NONE                | Customer[] | 200, 404      |
| "/customers/{id}"      | GET    | int ID              | Customer   | 200, 404      |
| "/customers/{email}"   | GET    | string Email        | Customer   | 200, 404      |
|                        |        |                     |            |               |
| "/customers"           | POST   | Customer            | NONE       | 200, 400      |
|                        |        |                     |            |               |
| "/customers/{id}"      | PATCH  | int ID, ???         | NONE       | 200, 400, 404 |
|                        |        |                     |            |               |
| "/customers/{id}"      | DELETE | int ID              | NONE       | 200, 404      |

### Orders
| Path                   | Method | Request             |  Response  | ResponseCodes |
| ---------------------- | ------ | ------------------- | ---------- | ------------- |
| "/orders"              | GET    | NONE                | Order[]    | 200, 404      |
| "/orders/{orderID}"    | GET    | int ID              | Order      | 200, 404      |
|                        |        |                     |            |               |
| "/orders"              | POST   | Order               | NONE       | 200, 400      |
|                        |        |                     |            |               |
| "/orders/{id}"         | PATCH  | int ID, ???         | NONE       | 200, 400, 404 |
|                        |        |                     |            |               |
| "/orders/{id}"         | DELETE | int ID              | NONE       | 200, 404      |

## Data
### Product
| Property Name | Data type | Description            |
| ------------- | --------- | ---------------------- |
| ID            | int       | ID of product          |
| Name          | string    | Name of product        |
| Price         | float     | Price of product       |
| Category      | string    | Category of product    |
| Description   | string    | Description of product |
| Discontinued  | bool      | Still in stock         |

### Customer
| Property Name |  Data type  | Description       |
| ------------- | ----------- | ----------------- |
| ID            | int         | ID of customer    |
| Firstname     | string      | Name of customer  |
| Lastname      | string      | Name of customer  |
| Adress        | string      | Adress of cutomer |
| Email         | string      | Email  of cutomer |
| Phone         | string      | Phone to cutomer  |
| Orders        | List<Order> | List of orders    |

### Order
|  Property Name |   Data type   | Description          |
| -------------- | ------------- | -------------------- |
| ID             | int           | ID of order          |
| CustomerId     | int           | Customer who ordered |
| DateOfOrder    | DateTime      | Time of order        |
| DateOfDelivery | DateTime      | Time of delivery     |
| Products       | List<Product> | List of products     |
