create or replace procedure public.PRC_UPSERT_CAR(
 in p_engine_size int,
    in p_fuel_type varchar,
    in p_manufacture_year int,
    in p_cd_chassis varchar,
    in p_cd_engine varchar,
    in p_brand_id int,
    in p_type_id int,
    in p_usage_id int,
    in p_model_id int,
    out status boolean,
    in p_id uuid DEFAULT null
)
language plpgsql
as $procedure$
declare
    v_found int;
begin
 if p_id is null then
     --insert data jika id tidak ada
     insert into "MST_CAR" (id, engine_size, fuel_type, manufacture_year, cd_chassis, cd_engine, brand_id, type_id, usage_id, model_id, dt_added)
     select gen_random_uuid(), p_engine_size, p_fuel_type, p_manufacture_year, p_cd_chassis, p_cd_engine, p_brand_id, p_type_id, p_usage_id, p_model_id, current_timestamp
     where not exists (
         select 1 from "MST_CAR"
         where engine_size = p_engine_size and fuel_type = p_fuel_type and manufacture_year = p_manufacture_year and cd_chassis = p_cd_chassis
         and cd_engine = p_cd_engine and brand_id = p_brand_id and type_id = p_type_id and usage_id = p_usage_id and model_id = model_id
     );
    else
     --update data jika ada id
     update "MST_CAR"
     set dt_updated = current_timestamp,
     engine_size = p_engine_size,
     fuel_type = p_fuel_type,
     manufacture_year = p_manufacture_year,
     cd_chassis = p_cd_chassis,
     cd_engine = p_cd_engine,
     brand_id = p_brand_id,
     type_id = p_type_id,
        usage_id = p_usage_id,
        model_id = model_id
     where id = p_id;
 end if;
    --cek apakah data sudah masuk
    select count(0)
    into v_found
    from "MST_CAR"
    where (id = p_id) or (engine_size = p_engine_size and fuel_type = p_fuel_type and manufacture_year = p_manufacture_year and cd_chassis = p_cd_chassis
         and cd_engine = p_cd_engine and brand_id = p_brand_id and type_id = p_type_id and usage_id = p_usage_id and model_id = model_id);

    --generate output
    if v_found > 0 then
        status:= true;
    else
        status:= false;
    end if;
    commit;
end;$procedure$
;