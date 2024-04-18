CREATE OR REPLACE VIEW public.vw_mst_type
AS SELECT mt.name,
    count(mc.id) AS count
   FROM "MST_TYPE" mt
     LEFT JOIN "MST_CAR" mc ON mt.id = mc.type_id
  GROUP BY mt.id; 