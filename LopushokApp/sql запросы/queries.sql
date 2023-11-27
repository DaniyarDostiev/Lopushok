--insert into [dbo].[MaterialType] ([name]) select distinct [dbo].[Material].[materialTypeId] from [dbo].[Material]

--update [dbo].[Material] set [materialTypeId] = [dbo].[MaterialType].[materialTypeId] from [dbo].[Material] join [dbo].[MaterialType] 
--on [dbo].[Material].[materialTypeId] = [dbo].[MaterialType].[name]


--insert into [dbo].[Measurement] ([name]) select distinct [dbo].[Material].[measurementId] from [dbo].[Material]


--update [dbo].[Material] set [measurementId] = [dbo].[Measurement].[measurementId] from [dbo].[Material] join [dbo].[Measurement]
--on [dbo].[Material].[measurementId] = [dbo].[Measurement].[name]



--insert into [dbo].[ProductType] ([name]) select distinct [dbo].[Product].[productTypeId] from [dbo].[Product]

--update [dbo].[Product] set [productTypeId] = [dbo].[ProductType].[productTypeId] from [dbo].[Product] join [dbo].[ProductType]
--on [dbo].[Product].[productTypeId] = [dbo].[ProductType].[name]



--update [dbo].[ProductMaterial] set [productArtcile] = [dbo].[Product].[productArcticle] from [dbo].[ProductMaterial] join [dbo].[Product]
--on [dbo].[ProductMaterial].[productArtcile] = [dbo].[Product].[name]

--update [dbo].[ProductMaterial] set [materialId] = [dbo].[Material].[materialId] from [dbo].[ProductMaterial] join [dbo].[Material]
--on [dbo].[ProductMaterial].[materialId] = [dbo].[Material].[name]