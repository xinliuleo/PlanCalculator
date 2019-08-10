import React from 'react';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import Divider from '@material-ui/core/Divider';
import ListItemText from '@material-ui/core/ListItemText';
import ListSubheader from '@material-ui/core/ListSubheader';

import Moment from 'moment';

const PaymentPlanList = (paymentPlans) => {
    Moment.locale('en');
    return (
        <div>
            {paymentPlans.data.map((list, key) => {
                return (
                    <List key={key}>
                        <div>
                            <ListSubheader>Instalment Amount: ${list.roundedInstalmentAmount}</ListSubheader>
                            <ListSubheader>Instalment Deposit: {list.formattedDeposit}</ListSubheader>
                            <ListSubheader>Instalment Dates:</ListSubheader>
                        </div>
                        {list.instalmentDates.map((instalmentDate, key) => {
                            return (

                                <ListItem key={key}>
                                    <ListItemText primary={Moment(instalmentDate).format('DD/MM/YYYY')} />
                                </ListItem>

                            )
                        })}
                        <Divider key={list.id} absolute />
                    </List>
                )
            })}
        </div>
    )
}

export default PaymentPlanList;