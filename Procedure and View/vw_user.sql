create or replace view public.vw_mst_user
as select mu.username as "Username",
	ms.name as "Name",
	mu.status as "Status"
from "MST_USER" mu 
join "MST_SALES" ms on mu.id_sales = ms.id_sales;
