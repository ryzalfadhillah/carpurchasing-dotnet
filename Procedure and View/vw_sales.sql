CREATE OR REPLACE VIEW public.vw_mst_sales
AS SELECT ms.name,
    ms.jumlah_penjualan,
    ms.komisi,
    mu.username,
    mu.status
   FROM "MST_SALES" ms
     LEFT JOIN "MST_USER" mu ON ms.id_sales = mu.id_sahles;