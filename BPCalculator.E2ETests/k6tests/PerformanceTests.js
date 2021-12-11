import { check, sleep } from "k6";
import http from "k6/http";

export let options = {

    stages: [
        { duration: "1m", target: 20 },
        { duration: "1m", target: 20 },
        { duration: "1m", target: 0 }
    ],

    thresholds: {
        "http_req_duration": ["p(95) < 400"]
    },

    discardResponseBodies: false,

    ext: {
        loadimpact: {
            distribution: {
                loadZoneLabel1: { loadZone: "amazon:ie:dublin", percent: 100 },
            }
        }
    }
};

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}

export default function() {

    let res = http.get("http://bp-x00192332-qa.azurewebsites.net", {"responseType": "text"});

    check(res, {
        "is status 200": (r) => r.status === 200
    });

    res = res.submitForm({
        fields: {
            BP_Systolic: getRandomInt(70, 190).toString(),
            BP_Diastolic: getRandomInt(40, 100).toString()
        }
    });

    check(res, {
        "is status 200": (r) => r.status === 200
    });

    sleep(3);
}