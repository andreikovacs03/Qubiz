import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Modal from '@material-ui/core/Modal';
import { Session } from 'shared/models/session.model';
import { Backdrop, Button, ButtonGroup, Fade, Grid, TextField, Typography } from '@material-ui/core';

import './session-add-form.css'

type Props = {
    onSubmit: (newSession: Session) => void;
    children?: string;
    color?: "inherit" | "default" | "primary" | "secondary" | undefined;
    size?: "small" | "medium" | "large" | undefined
}

const emptySession: Session = {
    id: 0, votes: 0, title: "", speaker: "", time: "", room: "", description: ""
}

function getModalStyle() {
    return {
        top: `50%`,
        left: `50%`,
        transform: `translate(-50%, -50%)`,
    };
}

const useStyles = makeStyles((theme) => ({
    paper: {
        position: 'absolute',
        backgroundColor: theme.palette.background.paper,
        border: '2px solid #000',
        boxShadow: theme.shadows[5],
        padding: theme.spacing(2, 4, 3),
    },
}));

export default function AddForm(props: Props) {
    const classes = useStyles();
    // getModalStyle is not a pure function, we roll the style only on the first render
    const [modalStyle] = React.useState(getModalStyle);
    const [open, setOpen] = React.useState(false);

    const handleOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const clickSubmit = () => {
        props.onSubmit(fields);
        handleClose();
    }
    const [fields, setFields] = React.useState(emptySession)

    const body = (
        <div style={modalStyle} className={classes.paper}>
            <Grid
                container
                direction="column"
                justify="space-evenly"
                alignItems="center"
                spacing={2}
            >
                <Grid item id="heading">
                    <Typography variant="h5" align="center">Add new session</Typography>
                </Grid>
                <Grid item>
                    <TextField label="Title" defaultValue={fields.title} onChange={e => setFields({ ...fields, title: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField label="Speaker" defaultValue={fields.speaker} onChange={e => setFields({ ...fields, speaker: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField label="Time" defaultValue={fields.time} onChange={e => setFields({ ...fields, time: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField label="Room" defaultValue={fields.room} onChange={e => setFields({ ...fields, room: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField label="Description" defaultValue={fields.description} onChange={e => setFields({ ...fields, description: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField label="Votes" defaultValue={fields.votes === 0 ? undefined : fields.votes} onChange={e => setFields({ ...fields, votes: parseInt(e.target.value) })} />
                </Grid>
                {/* Object.keys(fields).map(field => <TextField label={field} defaultValue={fields[field]} onChange={e => setFields(field, e.target.value)} />) */}
                <Grid item>
                    <ButtonGroup>
                        <Button onClick={clickSubmit} id="btn-submit" size="large">Submit</Button>
                    </ButtonGroup>
                </Grid>
            </Grid>
        </div>
    );

    return (
        <React.Fragment>
            <ButtonGroup>
                <Button type="button" onClick={handleOpen} color={props.color} size={props.size}>
                    {props.children}
                </Button>
            </ButtonGroup>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="simple-modal-title"
                aria-describedby="simple-modal-description"
                closeAfterTransition
                BackdropComponent={Backdrop}
                BackdropProps={{
                    timeout: 500,
                }}

            >
                <Fade in={open}>
                    {body}
                </Fade>
            </Modal>
        </React.Fragment>
    );
}
