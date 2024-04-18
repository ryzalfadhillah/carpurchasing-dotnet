create or replace view VW_MST_MODEL as
 select mm.id, mm.name, mb.name as "brand" from "MST_MODEL" mm
 join "MST_BRAND" mb on mb.id = mm.brand_id;

 