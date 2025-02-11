# ProductAPI

## 🚀 Features
- Retrieve all products
- Retrieve a product by ID
- Add a new product
- Update an existing product
- Delete a product by ID

## 🛠 Technologies Used
- **ASP.NET Core**
- **Entity Framework Core** (EF Core)
- **SQL Server**

---

## 📌 API Endpoints

### 🔍 Get All Products
```http
GET /api/products
```
📌 **Response:** Returns a list of all products.

---

### 🔍 Get Product by ID
```http
GET /api/products/{id}
```
📌 **Response:** Returns details of a specific product by ID.

---

### ➕ Add a New Product
```http
POST /api/products
```
📌 **Request Body (JSON):**
```json
{
    "productName": "New Laptop",
    "price": 1500.00,
    "stockQuantity": 15
}
```
📌 **Response:** Returns the created product with its assigned ID.

---

### ✏️ Update an Existing Product
```http
PUT /api/products/{id}
```
📌 **Request Body (JSON):**
```json
{
    "productId": 6,
    "productName": "Laptop Gaming",
    "price": 1200.99,
    "stockQuantity": 15
}
```
📌 **Response:** No content (204) if successful.

---

### ❌ Delete a Product by ID
```http
DELETE /api/products/{id}
```
📌 **Response:** No content (204) if successful.

---
