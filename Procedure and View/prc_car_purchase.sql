hcreate or replace procedure public.PRC_UPSERT_CAR_PURCHASE(in p_purchase_id uuid, in p_tenor int4, in p_down_payment numeric, in p_tax numeric, in p_price numeric, in p_payment_status varchar, in p_car_id uuid, in p_cust_id uuid, in p_user_id uuid, out out_mess varchar, out status bool)
language plpgsql
as $$
declare
v_purchasing_id int;
v_found int;
begin
 -- cek apakah id car purchase ada atau tidak untuk menentukan action (insert or update)
 if (p_purchase_id = "0") then --jika id ketika input 0 (buat type hidden value 0 di form)
  insert into "TRN_CAR_PURCHASE" (tenor, down_payment, tax, price, payment_status, car_id, cust_id, dt_added, dt_updated, id_user_added, id_user_updated)
  values (p_tenor, p_down_payment, p_tax, p_price, p_payment_status, p_car_id, p_cust_id, current_timestamp, current_timestamp, p_user_id, p_user_id)
  returning id into v_purchasing_id;
 else
  update "TRN_CAR_PURCHASE"
  set tenor = p_tenor, down_payment = p_down_payment, tax = p_tax, price = p_price, payment_status = p_payment_status,
  car_id = p_car_id, cust_id = p_cust_id, dt_updated = current_timestamp, id_user_updated = p_user_id
  where id = p_purchase_id returning id into v_purchasing_id;
 end if;

 -- cek input status
 select count(0) into v_found from "TRN_CAR_PURCHASE" where id = v_purchasing_id;

 --generate output
 if v_found > 0 then
  status := true;
  out_mess := 'input model successed';
 else
  status := false;
  out_mess := 'input model failed';
 end if;

 commit;
end; $$