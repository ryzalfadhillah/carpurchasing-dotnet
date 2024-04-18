create or replace procedure public.PRC_UPSERT_SALES(
 in p_id varchar,
 in p_name varchar,
 in p_jumlah_penjualan int4,
 in p_komisi int4,
 in p_user_id varchar,
 out out_stat boolean,
 out out_mess varchar
)
language plpgsql
as $prc_sales$
declare
 v_found boolean;
begin
 -- berikan input '0' pada p_id untuk update
 if(p_id != '0') then
  select exists(select 1 from "MST_SALES" where id_sales = p_id::uuid)
  into v_found;

  if v_found then
   update "MST_SALES" set("name", jumlah_penjualan, komisi, id_user_updated, dt_updated) =
    (p_name, p_jumlah_penjualan, p_komisi, p_user_id::uuid, current_timestamp) where id_sales = p_id::uuid;
   out_stat := true;
   out_mess := 'Sales ' || p_name || ' telah diperbarui dengan komisi '  || p_komisi || ' penjualan ' || p_jumlah_penjualan;
  else
   out_stat := false;
   out_mess := 'type tidak ditemukan';
  end if;
 else
  select exists(select 1 from "MST_SALES" where "name" like p_name)
  into v_found;

  if v_found then
   out_stat := false;
   out_mess := 'type duplikasi!';
  else
   insert into "MST_SALES"(id_sales, "name", jumlah_penjualan, komisi, id_user_added, dt_added)
    values(gen_random_uuid(), p_name, p_jumlah_penjualan, p_komisi, p_user_id::uuid, current_timestamp);
   out_stat := true;
   out_mess := 'Sales ' || p_name || ' telah ditambahkan dengan komisi '  || p_komisi || ' penjualan ' || p_jumlah_penjualan;
  end if;
 end if;
commit;
end $prc_sales$;