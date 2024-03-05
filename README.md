# WebDev-Labb2

# Planing for HandmadeApi

## Endpoints

### Products

| Path                   | Method | Request             | Response  | ResponseCodes |
| ---------------------- | ------ | ------------------- | --------- | ------------- |
| "/products"            | GET    | NONE                | Product[] | 200, 404      |
| "/products/{id}"       | GET    | int id              | Product   | 200, 404      |
| "/products/{Category}" | GET    | int id              | Product   | 200, 404      |
|                        |        |                     |           |               |
| "/products"            | POST   | Product             | NONE      | 200, 400      |
|                        |        |                     |           |               |
| "/products{id}"        | PATCH  | int id, float price | NONE      | 200, 400, 404 |
|                        |        |                     |           |               |
| "/products{id}"        | DELETE | int id              | NONE      | 200, 404      |
|                        |        |                     |           |               |

## Data

All data has id generation

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
