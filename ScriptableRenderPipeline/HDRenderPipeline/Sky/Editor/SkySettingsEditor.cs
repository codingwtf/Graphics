﻿using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.Rendering;

namespace UnityEngine.Experimental.Rendering.HDPipeline
{
    public abstract class SkySettingsEditor : VolumeComponentEditor
    {
        SerializedDataParameter m_SkyResolution;
        SerializedDataParameter m_SkyExposure;
        SerializedDataParameter m_SkyMultiplier;
        SerializedDataParameter m_SkyRotation;
        SerializedDataParameter m_EnvUpdateMode;
        SerializedDataParameter m_EnvUpdatePeriod;
        SerializedDataParameter m_LightingOverride;

        public override void OnEnable()
        {
            var o = new PropertyFetcher<SkySettings>(serializedObject);

            m_SkyResolution = Unpack(o.Find(x => x.resolution));
            m_SkyExposure = Unpack(o.Find(x => x.exposure));
            m_SkyMultiplier = Unpack(o.Find(x => x.multiplier));
            m_SkyRotation = Unpack(o.Find(x => x.rotation));
            m_EnvUpdateMode = Unpack(o.Find(x => x.updateMode));
            m_EnvUpdatePeriod = Unpack(o.Find(x => x.updatePeriod));
            m_LightingOverride = Unpack(o.Find(x => x.lightingOverride));
        }

        protected void CommonSkySettingsGUI()
        {
            PropertyField(m_SkyResolution);
            PropertyField(m_SkyExposure);
            PropertyField(m_SkyMultiplier);
            PropertyField(m_SkyRotation);

            PropertyField(m_EnvUpdateMode);
            if (!m_EnvUpdateMode.value.hasMultipleDifferentValues && m_EnvUpdateMode.value.intValue == (int)EnvironementUpdateMode.Realtime)
            {
                EditorGUI.indentLevel++;
                PropertyField(m_EnvUpdatePeriod);
                EditorGUI.indentLevel--;
            }
            PropertyField(m_LightingOverride);
        }
    }
}