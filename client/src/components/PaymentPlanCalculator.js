import React, { useState, useEffect } from 'react';
import useForm from 'react-hook-form';
import DatePicker from "react-datepicker";
import Input from "@material-ui/core/Input";
import Button from '@material-ui/core/Button';
import axios from 'axios';
import Moment from 'moment';
import "react-datepicker/dist/react-datepicker.css";

//import component
import PaymentPlanList from './PaymentPlanList';

const PaymentPlanCalculator = () => {
    Moment.locale('en');
    const { handleSubmit, register, setValue, setError, errors } = useForm();
    const onSubmit = (values) => {
        if (values.purchasedate === undefined) {
            setError('purchasedate', '', 'Purchase date is required');
            return;
        }
        const price = values.purchaseprice;
        const date = Moment(values.purchasedate).format('YYYY-MM-DD');

        axios.get(`http://localhost:5000/api/calculator?Price=${price}&Date=${date}`)
            .then(res => {
                setPaymentPlan({ data: res.data, error: '' });
            })
            .catch(err => {

                if (err.response !== undefined && err.response.status === 404) {
                    console.log(err.response);
                    setPaymentPlan({ data: [], error: err.response.data });
                }
                else {
                    console.log(err.response);
                    setPaymentPlan({ data: [], error: 'Service is unavailable, please try agian later' });
                }
            });
    }
    const [values, setReactDatePicker] = useState({
        pickedDate: ''
    });
    const handleDatePickerChange = pickedDate => {
        setValue("purchasedate", pickedDate);
        setReactDatePicker({ pickedDate });
    };

    useEffect(() => {
        register({
            name: "purchasedate",
            required: 'Required',
        });
    });

    const [paymentPlan, setPaymentPlan] = useState({ data: [], error: "" });
    return (
        <div className="Calculator">
            <h3>Payment Plan Calculator</h3>
            <form>
                <div>
                    <label for="purchaseprice">Purchase Price</label>
                    <br />
                    <Input
                        name="purchaseprice"
                        inputRef={register({
                            required: 'Purchase price is required',
                            pattern: {
                                value: /^\d+(\.\d{1,2})?$/i,
                                message: "invalid amount"
                            }
                        })}
                        placeholder="Enter purchase price"
                    />
                    <br />
                    {errors.purchaseprice && errors.purchaseprice.message}
                </div>

                <div>
                    <label for="purchasedate">Purchase Date</label>
                    <br />
                    <DatePicker
                        dateFormat="dd/MM/yyyy"
                        name="purchasedate"
                        selected={values.pickedDate}
                        onSelect={handleDatePickerChange}
                    />
                    <br />
                    {errors.purchasedate && errors.purchasedate.message}
                </div>
                <div>
                    <Button variant="contained" onClick={handleSubmit(onSubmit)}>
                        Get Payment Plan
                    </Button>
                </div>

            </form>
            <div>
                {paymentPlan.data.length === 0 ? <div>{paymentPlan.error}</div> : PaymentPlanList(paymentPlan)}
            </div>
        </div>
    )
}

export default PaymentPlanCalculator
