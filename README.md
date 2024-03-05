# WebDev-Labb2
# Planing for HandmadeApi

## Endpoints
### Products
| Path                   | Method | Request             | Response  | ResponseCodes |
| ---------------------- | ------ | ------------------- | --------- | ------------- |
| "/products"            | GET    | NONE                | Product[] | 200, 404      |
| "/products/{id}"       | GET    | int ID              | Product   | 200, 404      |
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
| "/cutomers"            | GET    | NONE                | Customer[] | 200, 404      |
| "/cutomers/{id}"       | GET    | int ID              | Customer   | 200, 404      |
| "/cutomers/{name}"     | GET    | string Name         | Customer   | 200, 404      |
|                        |        |                     |            |               |
| "/cutomers"            | POST   | Customer            | NONE       | 200, 400      |
|                        |        |                     |            |               |
| "/cutomers/{id}"       | PATCH  | int ID, ???         | NONE       | 200, 400, 404 |
|                        |        |                     |            |               |
| "/cutomers/{id}"       | DELETE | int ID              | NONE       | 200, 404      |

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

### Customer
| Property Name |  Data type  | Description       |
| ------------- | ----------- | ----------------- |
| ID            | int         | ID of customer    |
| Name          | string      | Name of customer  |
| Adress        | string      | Adress of cutomer |
| Email         | string      | Email  of cutomer |
| Orders        | List<Order> | List of orders    |

### Order
| Property Name |   Data type   | Description          |
| ------------- | ------------- | -------------------- |
| ID            | int           | ID of order          |
| CustomerId    | int           | Customer who ordered |
| DateOfOrder   | DateTime      | Time of order        |
| Products      | List<Product> | List of products     |
