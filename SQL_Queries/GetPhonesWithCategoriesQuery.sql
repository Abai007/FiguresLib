SELECT 
	p.Name, 
	c.Name 
FROM Products p
LEFT JOIN ProductCategory pc ON pc.ProductId = p.Id
LEFT JOIN Categories c ON c.Id = pc.CategoryId