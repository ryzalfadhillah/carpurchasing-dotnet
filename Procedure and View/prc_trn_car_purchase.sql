CREATE OR REPLACE PROCEDURE PRC_TRN_CAR_PURCHASE(
 IN p_id uuid,
    IN p_tenor INT,
    IN p_down_payment DECIMAL,
    IN p_tax DECIMAL,
    IN p_price DECIMAL,
    IN p_payment_status VARCHAR,
    IN p_car_id uuid,
    IN p_cust_id uuid,
    IN p_username uuid,
    OUT p_message VARCHAR
)
LANGUAGE plpgsql
AS $$
BEGIN
    IF exists (SELECT 1 FROM "TRN_CAR_PURCHASE" WHERE id = p_id) THEN
        UPDATE "TRN_CAR_PURCHASE" SET tenor = p_tenor, down_payment = p_down_payment, tax = p_tax, price = p_price, payment_status = p_payment_status, car_id = p_car_id, cust_id = p_cust_id, dt_updated = now(), id_user_updated = p_username WHERE id = p_id;
        p_message := 'Car Purchase ID ' || p_id || ' berhasil diupdate';
    ELSE
        INSERT INTO "TRN_CAR_PURCHASE" (id, tenor, down_payment, tax, price, payment_status, car_id, cust_id, dt_added, dt_updated, id_user_added, id_user_updated)
        values (gen_random_uuid(), p_tenor, p_down_payment, p_tax, p_price, p_payment_status, p_car_id, p_cust_id, now(), now(), p_username, p_username);
        p_message := 'Car Purchase ID ' || p_id || ' berhasil ditambahkan';
    END IF;
END; $$;